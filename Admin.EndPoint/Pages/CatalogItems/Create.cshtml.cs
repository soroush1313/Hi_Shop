using Hi_Shop.Application.Catalogs.CatalogItems.AddNewCatalogItem;
using Hi_Shop.Application.Catalogs.CatalogItems.CatalogItemServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Admin.EndPoint.Pages.CatalogItems
{
    public class CreateModel : PageModel
    {
        private readonly ICatalogItemService catalogItemService;
        private readonly IAddNewCatalogItemService addNewCatalogItemService;

        public CreateModel(IAddNewCatalogItemService addNewCatalogItemService, ICatalogItemService catalogItemService)
        {
            this.catalogItemService = catalogItemService;
            this.addNewCatalogItemService = addNewCatalogItemService;
        }

        public SelectList Categories { get; set; }
        public SelectList Brands { get; set; }

        [BindProperty]
        public AddNewCatalogItemDto Data { get; set; }

        public void OnGet()
        {
            Categories = new SelectList(catalogItemService.GetCatalogType(), "Id", "Type");
            Brands = new SelectList(catalogItemService.GetBrand(), "Id", "Brand");
        }
    }
}
