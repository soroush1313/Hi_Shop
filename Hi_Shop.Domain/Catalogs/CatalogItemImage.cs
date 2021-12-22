using Hi_Shop.Domain.Attributes;

namespace Hi_Shop.Domain.Catalogs
{
    [Auditable]
    public class CatalogItemImage
    {
        public int Id { get; set; }
        public string Src { get; set; }
        public CatalogItem CatalogItem { get; set; }
    }
}
