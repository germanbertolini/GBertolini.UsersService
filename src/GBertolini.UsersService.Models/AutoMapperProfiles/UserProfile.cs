using AutoMapper;
using GBertolini.UsersService.Models.Dto;
using GBertolini.UsersService.Models.Extensions;
using GBertolini.UsersService.Models.Models.Interfaces;

namespace GBertolini.UsersService.Models.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<IUser, UserDto>()
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
                        dest => dest.UserType,
                        opt => opt.MapFrom(src => src.ToEnum())
                    )
                    .ForMember(
                        dest => dest.Phone,
                        opt => opt.MapFrom(src => src.Phone)
                    )
                    .ForMember(
                        dest => dest.Money,
                        opt => opt.MapFrom(src => src.Money)
                    )
                    .ReverseMap();
        }
    }
}
