using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Hi_Shop.Application.Users;
using Hi_Shop.Domain.Users;

namespace Hi_Shop.Infrastructure.MappingProfile
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserAddress, UserAddressDto>();
            CreateMap<AddUserAddressDto, UserAddress>();
        }
    }
}
