using Microsoft.AspNetCore.Mvc;
using StoreApp.Data.Abstract;
using StoreApp.Data.Concrete;
using StoreApp.Models;

namespace StoreApp.Controllers
{
    public class AboutContactController : Controller
    {
        IStoreRepository _storeRepository;

        public AboutContactController(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public IActionResult About()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(ContactViewModel contactModel)
        {
            if (ModelState.IsValid)
            {
                _storeRepository.CreateContact(new Data.Concrete.Contact
                { 
                    FullName = contactModel.FullName, 
                    Email = contactModel.Email, 
                    Message = contactModel.Message,
                    Subject = contactModel.Subject
                });
                return View();
            }
            return View(contactModel);
        }
    }
}
