using Hi_Shop.Application.Catalogs.CatalogTypes.GetMenuItem;
using Microsoft.AspNetCore.Mvc;

namespace Hi_Shop.EndPoint.Models.ViewComponents
{
    public class GetMenuCategories : ViewComponent
    {
        private readonly IGetMenuItemService getMenuItemService;

        public GetMenuCategories(IGetMenuItemService getMenuItemService)
        {
            this.getMenuItemService = getMenuItemService;
        }

        public IViewComponentResult Invoke()
        {
            var data = getMenuItemService.Execute();
            return View(viewName: "GetMenuCategories" , model: data);
        }
    }
}
