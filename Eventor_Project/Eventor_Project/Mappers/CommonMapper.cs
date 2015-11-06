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

            Mapper.CreateMap<Models.ProjectModel.Material, Models.ViewModels.MaterialsJsonModel>();
            Mapper.CreateMap<Models.ProjectModel.Customer, Models.ViewModels.CustomerJsonModel>();
            Mapper.CreateMap<Models.ProjectModel.Organizer, Models.ViewModels.OrganizerJsonModel>();

            Mapper.CreateMap<Models.ProjectModel.Project, Models.ViewModels.ProjectCardViewModel>();
            Mapper.CreateMap<Models.ViewModels.ProjectCardViewModel, Models.ProjectModel.Project>();
        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            return Mapper.Map(source, sourceType, destinationType);
        }
    }
}
