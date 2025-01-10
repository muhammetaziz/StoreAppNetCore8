using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApp.Data.Abstract;
using StoreApp.Models;

namespace StoreApp.Controllers
{
    public class HomeController : Controller
    {
        public int pageSize = 12;
        private readonly ILogger<HomeController> _logger;
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;
        private readonly CartsModel _cart;

        public HomeController(ILogger<HomeController> logger, IStoreRepository storeRepository, IMapper mapper, CartsModel cart)
        {
            _logger = logger;
            _storeRepository = storeRepository;
            _mapper = mapper;
            _cart = cart;
        }

        public  IActionResult  Index(string category, int page = 1)
        {
            ViewBag.UrunSayisi = _cart.Items.Sum(i => i.Quantity);
            ViewBag.currentPage = page;
            return View(new ProductListViewModel
            {
                Products = _storeRepository.GetProductByCategory(category, page, pageSize)
                .Select(product => _mapper.Map<ProductViewModel>(product)),
                PageInfo = new PageInfo()
                {
                    ItemsPerPage = pageSize,
                    CurrentPage = page,
                    TotalItems = _storeRepository.GetProductCount(category)
                }
            });
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewBag.UrunSayisi = _cart.Items.Sum(i => i.Quantity);
            var product = await _storeRepository.Products.Where(x => x.ProductId == id).FirstOrDefaultAsync();
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}
