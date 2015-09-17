using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Eventor_Project.Models
{
    public class CurrentContext : DbContext 
    {
        public DbSet<User.User> Users { get; set; }
        public DbSet<User.Role> Roles { get; set; }
        public DbSet<User.Place> Places { get; set; }
        public DbSet<User.UserRole> UserRole { get; set; }
    }
}