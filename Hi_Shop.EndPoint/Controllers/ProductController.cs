using Hi_Shop.Application.Catalogs.CatalogItems.GetCatalogItemPLP;
using Microsoft.AspNetCore.Mvc;

namespace Hi_Shop.EndPoint.Controllers
{
    public class ProductController : Controller
    {
        private readonly IGetCatalogItemPLPService getCatalogItemPLPService;

        public ProductController(IGetCatalogItemPLPService getcatalogItemPlpService)
        {
            this.getCatalogItemPLPService = getcatalogItemPlpService;
        }
        public IActionResult Index(int page = 1 , int pageSize = 20)
        {
            var data = getCatalogItemPLPService.Execute(page, pageSize);
            return View(data);
        }
    }
}
