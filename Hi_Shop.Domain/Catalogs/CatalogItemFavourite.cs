using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hi_Shop.Domain.Attributes;

namespace Hi_Shop.Domain.Catalogs
{
    [Auditable]
    public class CatalogItemFavourite
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public CatalogItem CatalogItem { get; set; }
        public int CatalogItemId { get; set; }
    }
}
