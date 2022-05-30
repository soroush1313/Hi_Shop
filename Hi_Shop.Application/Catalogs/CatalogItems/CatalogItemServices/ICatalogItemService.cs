using AutoMapper;
using Hi_Shop.Application.Dtos;
using Hi_Shop.Application.Interfaces.Contexts;
using Hi_Shop.Common;
using Hi_Shop.Domain.Catalogs;
using Microsoft.EntityFrameworkCore;

namespace Hi_Shop.Application.Catalogs.CatalogItems.CatalogItemServices
{
    public interface ICatalogItemService
    {
        List<CatalogBrandDto> GetBrand();
        List<ListCatalogTypeDto> GetCatalogType();
        PaginatedItemsDto<CatalogItemListItemDto> GetCatalogList(int page, int pageSize);

        BaseDto<CatalogItemDto> Add(CatalogItemDto catalogItem);
        BaseDto Remove(int Id);
        BaseDto<CatalogItemDto> Edit(CatalogItemDto catalogItem);
        BaseDto<CatalogItemDto> FindById(int Id);

    }

    public class CatalogItemService : ICatalogItemService
    {
        private readonly IDataBaseContext context;
        private readonly IMapper mapper;

        public CatalogItemService(IDataBaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public BaseDto<CatalogItemDto> Add(CatalogItemDto catalogItem)
        {
            var model = mapper.Map<CatalogItem>(catalogItem);
            context.CatalogItems.Add(model);
            context.SaveChanges();
            return new BaseDto<CatalogItemDto>
            (
                true,
                new List<string> { $" با موفقیت در سیستم ثبت شد" },
                mapper.Map<CatalogItemDto>(model)
            );
        }

        public BaseDto<CatalogItemDto> Edit(CatalogItemDto catalogItem)
        {
            var model = context.CatalogItems.SingleOrDefault(p => p.Id == catalogItem.Id);
            mapper.Map(catalogItem, model);
            context.SaveChanges();
            return new BaseDto<CatalogItemDto>(
                true,
                new List<string> { $"با موفقیت ویرایش شد" },
                mapper.Map<CatalogItemDto>(model)
            );
        }

        public BaseDto<CatalogItemDto> FindById(int Id)
        {
            var data = context.CatalogItems.Find(Id);
            var result = mapper.Map<CatalogItemDto>(data);
            return new BaseDto<CatalogItemDto>
            (
                true,
                null,
                result
            );
        }

        public List<CatalogBrandDto> GetBrand()
        {
            var brands = context.CatalogBrands
                .OrderBy(p => p.Brand).Take(500).ToList();
            var data = mapper.Map<List<CatalogBrandDto>>(brands);
            return data;
        }

        public PaginatedItemsDto<CatalogItemListItemDto> GetCatalogList(int page, int pageSize)
        {
            int rowCount = 0;
            var data = context.CatalogItems
                .Include(p => p.CatalogType)
                .Include(p => p.CatalogBrand)
                .ToPaged(page, pageSize, out rowCount)
                .OrderByDescending(p => p.Id)
                .Select(p => new CatalogItemListItemDto
                {
                    Id = p.Id,
                    Brand = p.CatalogBrand.Brand,
                    Type = p.CatalogType.Type,
                    AvailableStock = p.AvailableStock,
                    MaxStockThreshold = p.MaxStockThreshold,
                    RestockThreshold = p.RestockThreshold,
                    Name = p.Name,
                    Price = p.Price
                }).ToList();

            return new PaginatedItemsDto<CatalogItemListItemDto>(page, page, rowCount, data);
        }

        public List<ListCatalogTypeDto> GetCatalogType()
        {
            var types1 = context.CatalogTypes.ToList();
            var types = context.CatalogTypes
                .Include(p => p.ParentCatalogType)
                .Include(p => p.ParentCatalogType)
                .ThenInclude(p => p.ParentCatalogType.ParentCatalogType)
                .Include(p => p.SubType)
                .Where(p => p.ParentCatalogTypeId != null)
                .Where(p => p.SubType.Count == 0)
                .Select(p => new { p.Id, p.Type, p.ParentCatalogType, p.SubType })
                .ToList()
                .Select(p => new ListCatalogTypeDto
                {
                    Id = p.Id,
                    Type = $"{p?.Type ?? ""} - {p?.ParentCatalogType?.Type ?? ""} - {p?.ParentCatalogType?.ParentCatalogType?.Type ?? ""}"
                }).ToList();
            return types;
        }

        public BaseDto Remove(int Id)
        {
            var catalogItem = context.CatalogItems.Find(Id);
            context.CatalogItems.Remove(catalogItem);
            context.SaveChanges();
            return new BaseDto
            (
                true,
                new List<string> { $"آیتم با موفقیت حذف شد" }
            );

        }
    }

    public class CatalogBrandDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }
    }

    public class ListCatalogTypeDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }

    public class CatalogItemListItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public int AvailableStock { get; set; }
        public int RestockThreshold { get; set; }
        public int MaxStockThreshold { get; set; }

    }

    public class CatalogItemDto
    {
        public int Id { get; set; }
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
