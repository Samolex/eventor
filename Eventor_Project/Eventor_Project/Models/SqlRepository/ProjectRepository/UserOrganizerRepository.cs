using Eventor_Project.Models.ProjectModel.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventor_Project.Models.SqlRepository
{
    public partial class SqlRepository
    {

        public IQueryable<UserOrganizer> UserOrganizers
        {
            get
            {
                return Db.UserOrganizers;
            }
        }

        public bool CreateUserOrganizer(UserOrganizer instance)
        {
            if (instance.UserOrganizerId == 0)
            {
                Db.UserOrganizers.Add(instance);
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool UpdateUserOrganizer(UserOrganizer instance)
        {
            UserOrganizer cache = Db.UserOrganizers.Where(p => p.UserOrganizerId == instance.UserOrganizerId).FirstOrDefault();
            if (cache != null)
            {
                //TODO : Update fields for UserOrganizer
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool DeleteUserOrganizer(int UserOrganizerId)
        {
            UserOrganizer instance = Db.UserOrganizers.Where(p => p.UserOrganizerId == UserOrganizerId).FirstOrDefault();
            if (instance != null)
            {
                Db.UserOrganizers.Remove(instance);
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public UserOrganizer ReadUserOrganizer(int UserOrganizerId)
        {
            UserOrganizer instance = Db.UserOrganizers.Where(p => p.UserOrganizerId == UserOrganizerId).FirstOrDefault();
            return instance;
        }
        
    }
}