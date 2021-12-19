using Application.Catalogs.CatalogTypes;
using AutoMapper;
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
        }
    }
}
