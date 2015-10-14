using AutoMapper;
using System;

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
