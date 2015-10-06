using AutoMapper;
using Eventor_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventor_Project.Mappers
{
    public class CommonMapper : IMapper
    {
        static CommonMapper()
        {
            Mapper.CreateMap<Models.User.User, Models.ViewModels.UserRegisterView>();
            Mapper.CreateMap<Models.ViewModels.UserRegisterView, Models.User.User>();

        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            return Mapper.Map(source, sourceType, destinationType);
        }
    }
}