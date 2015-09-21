using System.Data.Entity;
using Eventor_Project.Models.ProjectModel;
using Eventor_Project.Models.ProjectModel.Relations;

namespace Eventor_Project.Models
{
    public class CurrentContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Contacts> Contacts { get; set; }

        #region ProjectDbSets

        public DbSet<Project> Projects { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProjectComment> ProjectComments { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Organizer> Organisers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ProjectNews> ProjectNews { get; set; }

        #region Relations Project

        public DbSet<UserMaterial> UserMaterials { get; set; }

        #endregion

        #endregion
    }
}