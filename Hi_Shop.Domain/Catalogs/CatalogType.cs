using Hi_Shop.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hi_Shop.Domain.Catalogs
{
    [Auditable]
    public class CatalogType
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public int? ParentCatalogTypeId { get; set; }
        public CatalogType ParentCatalogType { get; set; }

        public ICollection<CatalogType> SubType { get;}
    }
}
