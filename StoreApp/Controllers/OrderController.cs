﻿using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Data.Abstract;
using StoreApp.Data.Concrete;
using StoreApp.Models;

namespace StoreApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly CartsModel cart;
        private readonly IOrderRepository _orderRepository;

        public OrderController(CartsModel cartService, IOrderRepository orderRepository)
        {
            cart = cartService;
            _orderRepository = orderRepository;
        }

        public IActionResult Checkout()
        {

            return View(new OrderModel() { CartsModel = cart });
        }
        [HttpPost]
        public IActionResult Checkout(OrderModel orderModel)
        {
            if (cart.Items.Count == 0)
            {
                ModelState.AddModelError("", "Sepetinizde ürün bulunmamaktadır.");

            }
            if (ModelState.IsValid)
            {
                var order = new Order()
                {
                    OrderDate = DateTime.Now,
                    Name = orderModel.Name,
                    Address = orderModel.Address,
                    Email = orderModel.Email,
                    Phone = orderModel.Phone,
                    City = orderModel.City,

                    OrderItems = cart.Items.Select(i => new StoreApp.Data.Concrete.OrderItem
                    {
                        ProductId = i.Product.ProductId,
                        Price = (double)i.Product.Price,
                        Quantity = i.Quantity
                    }).ToList()
                };
                orderModel.CartsModel = cart;
                var payment = ProcessPayment(orderModel);
                if (payment.Status == "succeeded")
                {

                    return RedirectToPage("/Complated", new { ID = order.OrderId });
                }


                _orderRepository.SaveOrder(order);
                cart.Clear();
                return RedirectToPage("/Complated", new { ID = order.OrderId });
            }
            else
            {
                orderModel.CartsModel = cart;
                return View(orderModel);
            }

        }
        private Payment ProcessPayment(OrderModel model)
        {
            Options options = new Options();
            options.ApiKey = "sandbox-wLn7ULhkaibGre62qG4SopUuVa0hgfZZ";
            options.SecretKey = "sandbox-zjjZzavpqNXT0qLxOdDqNjaJr1zmZIBH";
            options.BaseUrl = "https://sandbox-api.iyzipay.com";

            CreatePaymentRequest request = new CreatePaymentRequest();
            request.Locale = Locale.TR.ToString();
            request.ConversationId = new Random().Next(111111111, 999999999).ToString();
            request.Price = model.CartsModel?.CalculateTotal().ToString();
            request.PaidPrice = model.CartsModel?.CalculateTotal().ToString();
            request.Currency = Currency.TRY.ToString();
            request.Installment = 1;
            request.BasketId = "B67832";
            request.PaymentChannel = PaymentChannel.WEB.ToString();
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();

            PaymentCard paymentCard = new PaymentCard();
            paymentCard.CardHolderName = model.CartName;
            paymentCard.CardNumber = model.CartNumber?.ToString();
            paymentCard.ExpireMonth = model.ExpriationMonth;
            paymentCard.ExpireYear = model.ExpriationYear;
            paymentCard.Cvc = model.CVV;
            paymentCard.RegisterCard = 0;
            request.PaymentCard = paymentCard;

            Buyer buyer = new Buyer();
            buyer.Id = "BY789";
            buyer.Name = "John";
            buyer.Surname = "Doe";
            buyer.GsmNumber = "+905350000000";
            buyer.Email = "email@email.com";
            buyer.IdentityNumber = "74300864791";
            buyer.LastLoginDate = "2015-10-05 12:43:35";
            buyer.RegistrationDate = "2013-04-21 15:12:09";
            buyer.RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            buyer.Ip = "85.34.78.112";
            buyer.City = "Istanbul";
            buyer.Country = "Turkey";
            buyer.ZipCode = "34732";
            request.Buyer = buyer;

            Address shippingAddress = new Address();
            shippingAddress.ContactName = "Jane Doe";
            shippingAddress.City = "Istanbul";
            shippingAddress.Country = "Turkey";
            shippingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            shippingAddress.ZipCode = "34742";
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address();
            billingAddress.ContactName = "Jane Doe";
            billingAddress.City = "Istanbul";
            billingAddress.Country = "Turkey";
            billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            billingAddress.ZipCode = "34742";
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();
            foreach (var item in model?.CartsModel?.Items ?? Enumerable.Empty<CartItem>())
            {

                BasketItem firstBasketItem = new BasketItem();
                firstBasketItem.Id = item.Product.ProductId.ToString();
                firstBasketItem.Name = item.Product.Name;
                firstBasketItem.Category1 = "Collectibles";
                firstBasketItem.Category2 = "Accessories";
                firstBasketItem.ItemType = BasketItemType.PHYSICAL.ToString();
                firstBasketItem.Price = ((double)item.Product.Price).ToString();
                basketItems.Add(firstBasketItem);
            }



            Payment payment = Payment.Create(request, options);
            return payment;
        }

    }
}
