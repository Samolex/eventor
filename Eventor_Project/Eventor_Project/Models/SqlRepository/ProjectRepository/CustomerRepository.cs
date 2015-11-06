using System.Linq;
using Eventor_Project.Models.ProjectModel;
using System;

namespace Eventor_Project.Models.SqlRepository
{
    public partial class SqlRepository
    {
        public IQueryable<Customer> Customers
        {
            get { return Db.Customers; }
        }

        public bool CreateCustomer(Customer instance)
        {
            try
            {
                if (instance.CustomerId == 0)
                {
                    Db.Customers.Add(instance);
                    Db.SaveChanges();
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateCustomer(Customer instance)
        {
            try
            {
                Customer customer = Db.Customers.Find(instance.CustomerId);
                Type type = customer.GetType();

                foreach(var info in type.GetProperties())
                {
                    if(info.CanWrite)
                    {
                        var value = info.GetValue(instance);
                        if(value != null)
                        {
                            info.SetValue(customer, value, null);
                        }
                    }
                }
                Db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCustomer(int customerId)
        {
            try
            {
                var instance = Db.Customers.FirstOrDefault(p => p.CustomerId == customerId);
                if (instance == null) return false;
                Db.Customers.Remove(instance);
                Db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Customer ReadCustomer(int customerId)
        {
            var instance = Db.Customers.FirstOrDefault(p => p.CustomerId == customerId);
            return instance;
        }
    }
}