using AutoMapper;
using Hi_Shop.Application.Interfaces.Contexts;

namespace Hi_Shop.Application.Catalogs.CatalogItems.CatalogItemServices
{
    public interface ICatalogItemService
    {
        List<CatalogBrandDto> GetBrand();
        List<CatalogTypeDto> GetCatalogType();
    }

    public class CatalogItemService : ICatalogItemService
    {
        private readonly IDataBaseContext context;
        private readonly IMapper mapper;

        public AddNewCatalogItemService(IDataBaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public List<CatalogBrandDto> GetBrand()
        {
            throw new NotImplementedException();
        }

        public List<CatalogTypeDto> GetCatalogType()
        {
            throw new NotImplementedException();
        }
    }

    public class CatalogBrandDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }
    }

    public class CatalogTypeDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }
}
