using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBertolini.UsersService.Models.AutoMapperProfiles
{
    public static class MapperConfig
    {
        public static MapperConfiguration InitializeAutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UserProfile());
            });

            return config;
        }
    }
}
