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
        public DbSet<Organizer> Organisers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ProjectNews> ProjectNews { get; set; }

        #region Relations Project

        public DbSet<UserMaterial> UserMaterials { get; set; }
        public DbSet<UserCustomer> UserCustomers { get; set; }
        public DbSet<UserOrganizer> UserOrganizers { get; set; }

        #endregion

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    
}