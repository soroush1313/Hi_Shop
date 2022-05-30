using Admin.EndPoint.ViewModels.Catalogs;
using AutoMapper;
using Hi_Shop.Application.Catalogs.CatalogItems.CatalogItemServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Admin.EndPoint.Pages.CatalogItems
{
    public class EditModel : PageModel
    {
        private readonly ICatalogItemService catalogItemService;
        private readonly IMapper mapper;

        public EditModel(ICatalogItemService catalogItemService, IMapper mapper)
        {
            this.catalogItemService = catalogItemService;
            this.mapper = mapper;
        }

        [BindProperty]
        public CatalogItemViewModel CatalogItem { get; set; } = new CatalogItemViewModel();
        public List<string> Message { get; set; } = new List<string>();

        public void OnGet(int Id)
        {
            var model = catalogItemService.FindById(Id);
            if (model.IsSuccess)
                CatalogItem = mapper.Map<CatalogItemViewModel>(model.Data);
            Message = model.Message;
        }

        public IActionResult OnPost()
        {
            var model = mapper.Map<CatalogItemDto>(CatalogItem);
            var result = catalogItemService.Edit(model);
            Message = result.Message;
            CatalogItem = mapper.Map<CatalogItemViewModel>(result.Data);
            return Page();
        }
    }
}
