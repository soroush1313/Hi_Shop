using Application.Catalogs.CatalogTypes;
using AutoMapper;
using Hi_Shop.Application.Catalogs.CatalogItems.AddNewCatalogItem;
using Hi_Shop.Application.Catalogs.CatalogItems.CatalogItemServices;
using Hi_Shop.Application.Catalogs.CatalogTypes.GetMenuItem;
using Hi_Shop.Domain.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hi_Shop.Infrastructure.MappingProfile
{
    public class CatalogMappingProfile : Profile
    {
        public CatalogMappingProfile()
        {
            CreateMap<CatalogType, CatalogTypeDto>().ReverseMap();

            CreateMap<CatalogType, CatalogTypeListDto>()
                .ForMember(dest => dest.SubTypeCount, option =>
                  option.MapFrom(src => src.SubType.Count));

            CreateMap<CatalogType, MenuItemDto>()
                .ForMember(dest => dest.Name, opt =>
                   opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.ParentId, opt =>
                  opt.MapFrom(src => src.ParentCatalogTypeId))
                .ForMember(dest => dest.SubMenu, opt =>
                 opt.MapFrom(src => src.SubType));

            //----------------افزودن مورد جدید

            CreateMap<CatalogItemFeature, AddNewCatalogItemFeature_Dto>().ReverseMap();
            CreateMap<CatalogItemImage, AddNewCatalogItemImage_Dto>().ReverseMap();
            CreateMap<CatalogItem, AddNewCatalogItemDto>()
                .ForMember(dest => dest.Features, opt =>
                  opt.MapFrom(src => src.CatalogItemFeatures))
                .ForMember(dest=>dest.Images, opt=>
                opt.MapFrom(src=>src.CatalogItemImages)).ReverseMap();


            //--------------------
            CreateMap<CatalogBrand, CatalogBrandDto>().ReverseMap();
            CreateMap<CatalogType, CatalogTypeDto>().ReverseMap();
        }
    }
}
