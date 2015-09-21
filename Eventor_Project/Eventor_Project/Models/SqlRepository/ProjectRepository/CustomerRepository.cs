using System.Linq;
using Eventor_Project.Models.ProjectModel;

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
            var cache = Db.Customers.FirstOrDefault(p => p.CustomerId == instance.CustomerId);
            if (cache == null) return false;
            cache.Role = instance.Role;
            cache.MaxCount = instance.MaxCount;
            cache.MinCount = instance.MinCount;
            cache.Description = instance.Description;
            Db.SaveChanges();
            return true;
        }

        public bool DeleteCustomer(int customerId)
        {
            var instance = Db.Customers.FirstOrDefault(p => p.CustomerId == customerId);
            if (instance == null) return false;
            Db.Customers.Remove(instance);
            Db.SaveChanges();
            return true;
        }

        public Customer ReadCustomer(int customerId)
        {
            var instance = Db.Customers.FirstOrDefault(p => p.CustomerId == customerId);
            return instance;
        }
    }
}