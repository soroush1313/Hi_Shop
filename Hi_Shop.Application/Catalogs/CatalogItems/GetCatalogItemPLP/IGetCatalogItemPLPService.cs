using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hi_Shop.Application.Catalogs.CatalogItems.UriComposer;
using Hi_Shop.Application.Dtos;
using Hi_Shop.Application.Interfaces.Contexts;
using Hi_Shop.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Hi_Shop.Application.Catalogs.CatalogItems.GetCatalogItemPLP
{
    public interface IGetCatalogItemPLPService
    { 
        PaginatedItemsDto<CatalogPLPDto> Execute(int page , int pageSize);
    }


    public class GetCatalogItemPLPService : IGetCatalogItemPLPService
    {
        private readonly IDataBaseContext context;
        private readonly IUriComposerService uri;

        public GetCatalogItemPLPService(IDataBaseContext context , IUriComposerService uri)
        {
            this.context = context;
            this.uri = uri;
        }
        public PaginatedItemsDto<CatalogPLPDto> Execute(int page, int pageSize)
        {
            int rowCount = 0;
            var data = context.CatalogItems
                .Include(p => p.CatalogItemImages)
                .OrderByDescending(p => p.Id)
                .PagedResult(page, pageSize, out rowCount)
                .Select(p => new CatalogPLPDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Rate = 4,
                    Image = uri
                        .ComposeImageUri(p.CatalogItemImages.FirstOrDefault().Src)
                }).ToList();
            return new PaginatedItemsDto<CatalogPLPDto>(page,pageSize,rowCount,data);
        }
    }


    public class CatalogPLPDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public byte Rate { get; set; }
    }
}
