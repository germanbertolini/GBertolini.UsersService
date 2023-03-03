using AutoMapper;
using GBertolini.UsersService.Models.Dto;
using GBertolini.UsersService.Models.Enums;
using GBertolini.UsersService.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBertolini.UsersService.Models.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>()
                    .ForMember(
                        dest => dest.Name,
                        opt => opt.MapFrom(src => src.Name)
                    )
                    .ForMember(
                        dest => dest.Email,
                        opt => opt.MapFrom(src => src.Email)
                    )
                    .ForMember(
                        dest => dest.Address,
                        opt => opt.MapFrom(src => src.Address)
                    )
                    .ForMember(
                        dest => dest.Phone,
                        opt => opt.MapFrom(src => src.Phone)
                    )
                    .ForMember(
                        dest => dest.UserType,
                        opt => opt.MapFrom(src => src.UserType)
                    )
                    .ForMember(
                        dest => dest.Money,
                        opt => opt.MapFrom(src => src.Money)
                    )
                .ReverseMap();
        }
    }
}
