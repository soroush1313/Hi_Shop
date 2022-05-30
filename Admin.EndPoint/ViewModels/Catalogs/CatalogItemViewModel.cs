using System.ComponentModel.DataAnnotations;

namespace Admin.EndPoint.ViewModels.Catalogs
{
    public class CatalogItemViewModel
    {
        public int Id { get; set; }
        [Display(Name = "نام آیتم")]
        [Required]
        [MaxLength(100, ErrorMessage = "حداکثر باید 100 کاراکتر باشد")]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int CatalogTypeId { get; set; }
        public int CatalogBrandId { get; set; }
        public int AvailableStock { get; set; }
        public int RestockThreshold { get; set; }
        public int MaxStockThreshold { get; set; }
    }
}
