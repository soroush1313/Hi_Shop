using AutoMapper;
using Hi_Shop.Application.Dtos;
using Hi_Shop.Application.Interfaces.Contexts;
using Hi_Shop.Domain.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hi_Shop.Application.Catalogs.CatalogItems.AddNewCatalogItem
{
    public interface IAddNewCatalogItemService
    {
        BaseDto<int> Execute(AddNewCatalogItemDto request);
    }

    public class AddNewCatalogItemService : IAddNewCatalogItemService
    {
        private readonly IDataBaseContext context;
        private readonly IMapper mapper;

        public AddNewCatalogItemService(IDataBaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public BaseDto<int> Execute(AddNewCatalogItemDto request)
        {
            var catalogItem = mapper.Map<CatalogItem>(request);
            context.CatalogItems.Add(catalogItem);
            context.SaveChanges();
            return new BaseDto<int>(true, new List<string> { "با موفقیت ثبت شد" }, catalogItem.Id);
        }
    }

    public class AddNewCatalogItemDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int CatalogTypeId { get; set; }
        public int CatalogBrandId { get; set; }
        public int AvailableStock { get; set; }
        public int RestockThreshold { get; set; }
        public int MaxStockThreshold { get; set; }
        public List<AddNewCatalogItemFeature_Dto> Features { get; set; }
        public List<AddNewCatalogItemImage_Dto> Images { get; set; }
    }

    public class AddNewCatalogItemFeature_Dto
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string Group { get; set; }
    }

    public class AddNewCatalogItemImage_Dto
    {
        public string Src { get; set; }
    }
}
