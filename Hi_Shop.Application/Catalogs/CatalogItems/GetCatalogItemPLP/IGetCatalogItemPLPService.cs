using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hi_Shop.Application.Catalogs.CatalogItems.UriComposer;
using Hi_Shop.Application.Dtos;
using Hi_Shop.Application.Interfaces.Contexts;
using Hi_Shop.Common;
using Hi_Shop.Domain.Catalogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Hi_Shop.Application.Catalogs.CatalogItems.GetCatalogItemPLP
{
    public interface IGetCatalogItemPLPService
    {
        PaginatedItemsDto<CatalogPLPDto> Execute(CatalogPLPRequestDto request);
    }


    public class GetCatalogItemPLPService : IGetCatalogItemPLPService
    {
        private readonly IDataBaseContext context;
        private readonly IUriComposerService uri;

        public GetCatalogItemPLPService(IDataBaseContext context, IUriComposerService uri)
        {
            this.context = context;
            this.uri = uri;
        }
        public PaginatedItemsDto<CatalogPLPDto> Execute(CatalogPLPRequestDto request)
        {
            int rowCount = 0;
            var query = context.CatalogItems
                .Include(p => p.Discounts)
                .Include(p => p.CatalogItemImages)
                .OrderByDescending(p => p.Id)
                .AsQueryable();

            if (request.BrandId != null)
            {
                query = query.Where(p => request.BrandId.Any(b => b == p.CatalogBrandId));
            }

            if (request.CatalogTypeId != null)
            {
                query = query.Where(p => p.CatalogTypeId == request.CatalogTypeId);
            }

            if (!string.IsNullOrEmpty(request.SearchKey))
            {
                query = query.Where(p => p.Name.Contains(request.SearchKey)
                                         || p.Description.Contains(request.SearchKey));
            }

            if (request.AvailableStock == true)
            {
                query = query.Where(p => p.AvailableStock > 0);
            }

            if (request.SortType == SortType.BestSelling)
            {
                query = query.Include(p => p.OrderItems)
                    .OrderByDescending(p=>p.OrderItems.Count());
            }

            if (request.SortType == SortType.MostPopular)
            {
                query = query.Include(p => p.CatalogItemFavourites)
                    .OrderByDescending(p => p.CatalogItemFavourites.Count());
            }
            if (request.SortType == SortType.MostVisited)
            {
                query = query.OrderByDescending(p => p.VisitCount);
            }
            if (request.SortType == SortType.Newest)
            {
                query = query.OrderByDescending(p => p.Id);
            }
            if (request.SortType == SortType.Cheapest)
            {
                query = query.Include(p => p.Discounts).OrderBy(p => p.Price);
            }
            if (request.SortType == SortType.MostExpensive)
            {
                query = query.Include(p => p.Discounts).OrderByDescending(p=>p.Price);
            }


            var data = query.PagedResult(request.Page, request.PageSize, out rowCount)
            .ToList()
            .Select(p => new CatalogPLPDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Rate = 4,
                Image = uri
                    .ComposeImageUri(p.CatalogItemImages.FirstOrDefault().Src),
                AvailableStock = p.AvailableStock
            }).ToList();
            return new PaginatedItemsDto<CatalogPLPDto>(request.Page, request.PageSize, rowCount, data);
        }
    }


    public class CatalogPLPRequestDto
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int? CatalogTypeId { get; set; }
        public int[] BrandId { get; set; }
        public bool AvailableStock { get; set; }
        public string SearchKey { get; set; }
        public SortType SortType { get; set; }
    }

    public enum SortType
    {
        /// <summary>
        /// بدون مرتب سازی
        /// </summary>
        None = 0,

        /// <summary>
        /// پر بازدیدترین
        /// </summary>
        MostVisited = 1,

        /// <summary>
        /// پر فروش ترین
        /// </summary>
        BestSelling = 2,

        /// <summary>
        /// محبوب ترین
        /// </summary>
        MostPopular = 3,

        /// <summary>
        /// جدیدترین
        /// </summary>
        Newest = 4,

        /// <summary>
        /// ارزان ترین
        /// </summary>
        Cheapest = 5,

        /// <summary>
        /// گران ترین
        /// </summary>
        MostExpensive = 6
    }


    public class CatalogPLPDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public byte Rate { get; set; }
        public int AvailableStock { get; set; }
    }
}
