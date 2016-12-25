using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eventor_Project.Models.ProjectModel;
using Eventor_Project.Models.ProjectModel.Relations;

namespace Eventor_Project.Models.SqlRepository
{
    public interface IRepository
    {
        User.User GetUser(string email);
        User.User GetUser(int id);
        User.User Login(string email, string password);


        #region Picture

        IQueryable<Picture> Pictures { get; }

        bool CreatePicture(Picture instance);

        bool UpdatePicture(Picture instance);

        bool DeletePicture(int PictureId);

        Picture ReadPicture(int PictureId);

        #endregion

        #region Role

        IQueryable<User.Role> Roles { get; }

        bool CreateRole(User.Role instance);

        bool UpdateRole(User.Role instance);

        bool DeleteRole(int RoleId);

        User.Role ReadRole(int RoleId);

        #endregion

        #region User

        IQueryable<User.User> Users { get; }

        bool CreateUser(User.User instance);

        bool UpdateUser(User.User instance);

        bool DeleteUser(int UserId);

        User.User ReadUser(int UserId);

        #endregion   

        #region Benefit

        IQueryable<User.Benefit> Benefits { get; }

        bool CreateBenefit(User.Benefit instance);

        bool UpdateBenefit(User.Benefit instance);

        bool DeleteBenefit(int BenefitId);
        User.Benefit ReadBenefit(int BenefitId);

        #endregion 

        #region Place

        IQueryable<User.Place> Places { get; }

        bool CreatePlace(User.Place instance);

        bool UpdatePlace(User.Place instance);

        bool DeletePlace(int PlaceId);

        User.Place ReadPlace(int PlaceId);

        #endregion 

        #region Message
        IQueryable<User.Message> Messages { get; }

        bool CreateMessage(User.Message instance);

        bool UpdateMessage(User.Message instance);

        bool DeleteMessage(int MessageId);
        User.Message ReadMessage(int MessageId);
#endregion

        #region ProjectRepository
        #region Category

        IQueryable<Category> Categories { get; }

        bool CreateCategory(Category instance);

        bool UpdateCategory(Category instance);

        bool DeleteCategory(int CategoryId);

        Category ReadCategory(int CategoryId);

        #endregion

        #region Customer

        IQueryable<Customer> Customers { get; }

        bool CreateCustomer(Customer instance);

        bool UpdateCustomer(Customer instance);

        bool DeleteCustomer(int CustomerId);

        Customer ReadCustomer(int CustomerId);

        void SaveCustomers(List<Customer> customer);
        #endregion

        #region Material

        IQueryable<Material> Materials { get; }

        bool CreateMaterial(Material instance);

        bool UpdateMaterial(Material instance);

        bool DeleteMaterial(int MaterialId);

        Material ReadMaterial(int MaterialId);
        void SaveMaterials(List<Material> materials);

        #endregion

        #region Organizer

        IQueryable<Organizer> Organisers { get; }

        bool CreateOrganizer(Organizer instance);

        bool UpdateOrganizer(Organizer instance);

        bool DeleteOrganizer(int OrganizerId);

        Organizer ReadOrganizer(int OrganizerId);

        void SaveOrganisers(List<Organizer> organisers);
        #endregion

        #region ProjectComment

        IQueryable<ProjectComment> ProjectComments { get; }

        bool CreateProjectComment(ProjectComment instance);

        bool UpdateProjectComment(ProjectComment instance);

        bool DeleteProjectComment(int ProjectCommentId);

        ProjectComment ReadProjectComment(int ProjectCommentId);

        #endregion

        #region ProjectNews

        IQueryable<ProjectNews> ProjectNews { get; }

        bool CreateProjectNews(ProjectNews instance);

        bool UpdateProjectNews(ProjectNews instance);

        bool DeleteProjectNews(int ProjectNewsId);

        ProjectNews ReadProjectNews(int ProjectNewsId);

        #endregion

        #region Project

        IQueryable<Project> Projects { get; }

        bool CreateProject(Project instance);

        bool UpdateProject(Project instance);

        bool DeleteProject(int ProjectId);

        Project ReadProject(int ProjectId);

        #endregion

        #region UserMaterial

        IQueryable<UserMaterial> UserMaterials { get; }

        bool CreateUserMaterial(UserMaterial instance);

        bool UpdateUserMaterial(UserMaterial instance);

        bool DeleteUserMaterial(int UserMaterialId);

        UserMaterial ReadUserMaterial(int UserMaterialId);

        #endregion
#endregion
    }
}
