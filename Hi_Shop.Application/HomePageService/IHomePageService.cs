using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hi_Shop.Application.Catalogs.CatalogItems.GetCatalogItemPLP;
using Hi_Shop.Application.Catalogs.CatalogItems.UriComposer;
using Hi_Shop.Application.Interfaces.Contexts;
using Hi_Shop.Domain.Banners;

namespace Hi_Shop.Application.HomePageService
{
    public interface IHomePageService
    {
        HomePageDto GetData();
    }

    public class HomePageService : IHomePageService
    {
        private readonly IDataBaseContext context;
        private readonly IUriComposerService uriComposerService;
        private readonly IGetCatalogItemPLPService getCatalogIItemPLPService;

        public HomePageService(IDataBaseContext context
            , IUriComposerService uriComposerService
            , IGetCatalogItemPLPService getCatalogIItemPLPService)
        {
            this.context = context;
            this.uriComposerService = uriComposerService;
            this.getCatalogIItemPLPService = getCatalogIItemPLPService;
        }


        public HomePageDto GetData()
        {
            var banners = context.Banners.Where(p => p.IsActive == true)
                .OrderBy(p => p.Priority)
                .ThenByDescending(p => p.Id)
                .Select(p => new BannerDto
                {
                    Id = p.Id,
                    Image = uriComposerService.ComposeImageUri(p.Image),
                    Link = p.Link,
                    Position = p.Position,
                }).ToList();

            var Bestselling = getCatalogIItemPLPService.Execute(new CatalogPLPRequestDto
            {
                AvailableStock = true,
                Page = 1,
                PageSize = 20,
                SortType = SortType.BestSelling
            }).Data.ToList();

            var MostPopular = getCatalogIItemPLPService.Execute(new CatalogPLPRequestDto
            {
                AvailableStock = true,
                Page = 1,
                PageSize = 20,
                SortType = SortType.MostPopular
            }).Data.ToList();

            return new HomePageDto
            { 
                Banners = banners,
                bestSellers = Bestselling,
                MostPopular = MostPopular,
            };
        }
    }

    public class HomePageDto
    {
        public List<BannerDto> Banners { get; set; }
        public List<CatalogPLPDto> MostPopular { get; set; }
        public List<CatalogPLPDto> bestSellers { get; set; }


    }

    public class BannerDto
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }
        public Position Position { get; set; }
    }
}
