using Eventor_Project.Models.ProjectModel.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventor_Project.Models.SqlRepository
{
    public partial class SqlRepository
    {
        public IQueryable<UserCustomer> UserCustomers
        {
            get
            {
                return Db.UserCustomers;
            }
        }

        public bool CreateUserCustomer(UserCustomer instance)
        {
            if (instance.UserCustomerId == 0)
            {
                Db.UserCustomers.Add(instance);
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool UpdateUserCustomer(UserCustomer instance)
        {
            UserCustomer cache = Db.UserCustomers.Where(p => p.UserCustomerId == instance.UserCustomerId).FirstOrDefault();
            if (cache != null)
            {
                //TODO : Update fields for UserCustomer
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool DeleteUserCustomer(int UserCustomerId)
        {
            UserCustomer instance = Db.UserCustomers.Where(p => p.UserCustomerId == UserCustomerId).FirstOrDefault();
            if (instance != null)
            {
                Db.UserCustomers.Remove(instance);
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public UserCustomer ReadUserCustomer(int UserCustomerId)
        {
            UserCustomer instance = Db.UserCustomers.Where(p => p.UserCustomerId == UserCustomerId).FirstOrDefault();
            return instance;
        }
        
    }
}