using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventor_Project.Models.SqlRepository
{
    public partial class SqlRepository : IRepository
    {

        public IQueryable<User.Role> Roles
        {
            get
            {
                return Db.Roles;
            }
        }

        public bool CreateRole(User.Role instance)
        {
            if (instance.RoleId == 0)
            {
                Db.Roles.Add(instance);
                Db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateRole(User.Role instance)
        {
            User.Role cache = Db.Roles.Where(p => p.RoleId == instance.RoleId).FirstOrDefault();
            if (cache != null)
            {
                cache.Code = instance.Code;
                cache.Name = instance.Name;
                cache.Users = instance.Users;
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool DeleteRole(int RoleId)
        {
            User.Role instance = Db.Roles.FirstOrDefault(p => p.RoleId == RoleId);
            if (instance != null)
            {
                Db.Roles.Remove(instance);
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public User.Role ReadRole(int RoleId)
        {
            User.Role instance = Db.Roles.Where(p => p.RoleId == RoleId).FirstOrDefault();
            return instance;
        }
    }
}