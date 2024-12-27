using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Data.Abstract;
using StoreApp.Models;

namespace StoreApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStoreRepository _storeRepository;

        public HomeController(ILogger<HomeController> logger, IStoreRepository storeRepository)
        {
            _logger = logger;
            _storeRepository = storeRepository;
        }

        public IActionResult Index()
        {
            var products = _storeRepository.Products.ToList();
            return View(new ProductViewModel
            {

            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
