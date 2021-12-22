using Hi_Shop.Domain.Attributes;

namespace Hi_Shop.Domain.Catalogs
{
    [Auditable]
    public class CatalogItemFeature
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Group { get; set; }
        public CatalogItem CatalogItem { get; set; }
        public int CatalogItemId { get; set; }
    }
}
