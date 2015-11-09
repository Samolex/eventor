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

            Mapper.CreateMap<Models.ProjectModel.Material, Models.ViewModels.MaterialsJsonModel>();
            Mapper.CreateMap<Models.ProjectModel.Customer, Models.ViewModels.CustomerJsonModel>();
            Mapper.CreateMap<Models.ProjectModel.Organizer, Models.ViewModels.OrganizerJsonModel>();

            Mapper.CreateMap<Models.ProjectModel.Project, Models.ViewModels.ProjectCardViewModel>();
            Mapper.CreateMap<Models.ViewModels.ProjectCardViewModel, Models.ProjectModel.Project>();

            Mapper.CreateMap<Models.User.Message, Models.ViewModels.MessageView>()
                .ForMember(x => x.PrevMessage, y => y.MapFrom(
                    z => (z.PrevMessageId == null ? null : Repository.ReadMessage((int)z.PrevMessageId)))
                );
            Mapper.CreateMap<Models.ViewModels.MessageView, Models.User.Message>()
                .ForMember(x => x.DepartureTime, y => y.MapFrom(_ => DateTime.UtcNow))
                .ForMember(x => x.PrevMessageId, y => y.MapFrom(z => z.PrevMessage.MessageId));
        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            return Mapper.Map(source, sourceType, destinationType);
        }
    }
}
