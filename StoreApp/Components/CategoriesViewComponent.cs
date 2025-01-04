using Microsoft.AspNetCore.Mvc;
using StoreApp.Data.Abstract;

namespace StoreApp.Components
{
    public class CategoriesViewComponent:ViewComponent
    {
        private IStoreRepository _storeRepository;

        public CategoriesViewComponent(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories=_storeRepository.Products.Select(i=>i.Category).Distinct().OrderBy(i=>i);
            return View(categories);
        }
    }
}
