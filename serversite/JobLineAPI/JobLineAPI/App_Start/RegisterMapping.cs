using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using JobLineAPI.Models;
using JobLineBUS.Dtos;

namespace JobLineAPI.App_Start
{
    public static class RegisterMapping
    {
        public static void Register()
        {
            Mapper.CreateMap<BaseModel, BaseDto>().ReverseMap();
            Mapper.CreateMap<UserModel, UserDto>().ReverseMap();
            Mapper.CreateMap<UserProfileModel, UserProfileDto>().ReverseMap();
            Mapper.CreateMap<RoleModel, RoleDto>().ReverseMap();
        }
    }
}