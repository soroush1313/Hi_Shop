using Hi_Shop.Domain.Attributes;
using Hi_Shop.Domain.Discounts;

namespace Hi_Shop.Domain.Catalogs
{
    [Auditable]
    public class CatalogItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int CatalogTypeId { get; set; }
        public CatalogType CatalogType { get; set; }
        public int CatalogBrandId { get; set; }
        public CatalogBrand CatalogBrand { get; set; }
        //tedad mojude
        public int AvailableStock { get; set; }
        //mojudie mahsul be kmtr az in meqdar resid sharzh konim
        public int RestockThreshold { get; set; }
        //saghfe sefaresh
        public int MaxStockThreshold { get; set; }

        public ICollection<CatalogItemFeature> CatalogItemFeatures { get; set; }
        public ICollection<CatalogItemImage> CatalogItemImages { get; set; }
        public ICollection<Discount> Discounts { get; set; }
    }
}
