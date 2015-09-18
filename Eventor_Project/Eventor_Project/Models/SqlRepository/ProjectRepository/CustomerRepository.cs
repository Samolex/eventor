using Eventor_Project.Models.ProjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventor_Project.Models.SqlRepository
{
    public partial class SqlRepository
    {

        public IQueryable<Customer> Customers
        {
            get
            {
                return Db.Customers;
            }
        }

        public bool CreateCustomer(Customer instance)
        {
            if (instance.CustomerId == 0)
            {
                Db.Customers.Add(instance);
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool UpdateCustomer(Customer instance)
        {
            Customer cache = Db.Customers.Where(p => p.CustomerId == instance.CustomerId).FirstOrDefault();
            if (cache != null)
            {
                //TODO : Update fields for Customer
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool DeleteCustomer(int CustomerId)
        {
            Customer instance = Db.Customers.Where(p => p.CustomerId == CustomerId).FirstOrDefault();
            if (instance != null)
            {
                Db.Customers.Remove(instance);
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public Customer ReadCustomer(int CustomerId)
        {
            Customer instance = Db.Customers.Where(p => p.CustomerId == CustomerId).FirstOrDefault();
            return instance;
        }
        
    }
}