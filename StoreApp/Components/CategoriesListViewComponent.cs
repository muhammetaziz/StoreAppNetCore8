using Microsoft.AspNetCore.Mvc;
using StoreApp.Data.Abstract;
using StoreApp.Models;

namespace StoreApp.Components
{
    public class CategoriesListViewComponent : ViewComponent
    {
        private readonly IStoreRepository _storeRepository;

        public CategoriesListViewComponent(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory=RouteData?.Values["category"];
            // var categories=_storeRepository.Categories.Select(p=>p.Name).OrderBy(i=>i);
            return View(_storeRepository.Categories.Select(c => new CategoryViewModel
            {
                CategoryId = c.CategoryId,
                Name = c.Name,
                Description = c.Description,
                Url = c.Url,

            }).ToList());
        }
    }
}
