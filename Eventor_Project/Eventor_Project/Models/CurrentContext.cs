using Eventor_Project.Models.ProjectModel;
using Eventor_Project.Models.ProjectModel.Relations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Eventor_Project.Models
{
    public partial class CurrentContext : DbContext 
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
        public DbSet<Money> Moneys { get; set; }
        public DbSet<Organizer> Organisers { get; set; }
        public DbSet<ProjectNews> ProjectNews { get; set; }

        #region Relations Project

        public DbSet<UserMaterial> UserMaterial { get; set; }
        public DbSet<UserMoney> UserMoney { get; set; }
        public DbSet<UserProject> UserProject { get; set; }

        #endregion

        #endregion
    }
}