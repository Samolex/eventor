using System.Linq;
using Eventor_Project.Models.ProjectModel;
using Eventor_Project.Models.ProjectModel.Relations;

namespace Eventor_Project.Models.SqlRepository
{
    public interface IRepository
    {
        CurrentContext Db { get; set; }

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

        #endregion

        #region Material

        IQueryable<Material> Materials { get; }

        bool CreateMaterial(Material instance);

        bool UpdateMaterial(Material instance);

        bool DeleteMaterial(int MaterialId);

        Material ReadMaterial(int MaterialId);

        #endregion

        #region Organizer

        IQueryable<Organizer> Organisers { get; }

        bool CreateOrganizer(Organizer instance);

        bool UpdateOrganizer(Organizer instance);

        bool DeleteOrganizer(int OrganizerId);

        Organizer ReadOrganizer(int OrganizerId);

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
    }
}