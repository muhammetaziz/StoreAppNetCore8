using System.Diagnostics;
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

        public HomeController(ILogger<HomeController> logger, IStoreRepository storeRepository)
        {
            _logger = logger;
            _storeRepository = storeRepository;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var products = await _storeRepository
                .Products
                .Skip((page - 1) * pageSize)
                .Select(p =>
                new ProductViewModel
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Category = p.Category,
                    Description = p.Description,
                    Price = p.Price,
                }).Take(pageSize).ToListAsync();
            ViewBag.currentPage = page;
            return View(new ProductListViewModel
            { 
                Products = products,
                PageInfo = new PageInfo()
                {
                    ItemsPerPage = pageSize,
                    TotalItems = _storeRepository.Products.Count(),
                    CurrentPage=page,
                }
            });
        }



    }
}
