using AutoMapper;
using System;
using Eventor_Project.Models.SqlRepository;
using Ninject;

namespace Eventor_Project.Mappers
{
    public class CommonMapper : IMapper
    {
        [Inject]
        private static IRepository Repository;
        static CommonMapper()
        {
            Mapper.CreateMap<Models.User.User, Models.ViewModels.UserRegisterView>();
            Mapper.CreateMap<Models.ViewModels.UserRegisterView, Models.User.User>()
                .ForMember(x => x.ContactEmail, y => y.MapFrom(z => z.Email));

            Mapper.CreateMap<Models.User.Message, Models.ViewModels.MessageView>();
            Mapper.CreateMap<Models.ViewModels.MessageView, Models.User.Message>()
                .ForMember(x => x.DepartureTime, y => y.MapFrom(_ => DateTime.UtcNow));
        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            return Mapper.Map(source, sourceType, destinationType);
        }
    }
}
