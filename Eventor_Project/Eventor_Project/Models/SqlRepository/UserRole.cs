using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventor_Project.Models.SqlRepository
{
    public partial class SqlRepository
    {
        

        public IQueryable<User.UserRole> Tables
        {
            get
            {
                return Db.UserRole;
            }
        }

        public bool CreateTable(User.UserRole instance)
        {
            if (instance.UserRoleId == 0)
            {
                Db.UserRole.Add(instance);
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool UpdateTable(User.UserRole instance)
        {
            User.UserRole cache = Db.UserRole.Where(p => p.UserRoleId == instance.UserRoleId).FirstOrDefault();
            if (cache != null)
            {
                //TODO : Update fields for Table
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool DeleteTable(int UserRoleId)
        {
            User.UserRole instance = Db.UserRole.Where(p => p.UserRoleId == UserRoleId).FirstOrDefault();
            if (instance != null)
            {
                Db.UserRole.Remove(instance);
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public User.UserRole ReadTable(int UserRoleId)
        {
            User.UserRole instance = Db.UserRole.Where(p => p.UserRoleId == UserRoleId).FirstOrDefault();
            return instance;
        }
        
 
        
    }
}