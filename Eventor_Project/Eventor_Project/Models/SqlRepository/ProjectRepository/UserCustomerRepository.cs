using Eventor_Project.Models.ProjectModel.Relations;
using System.Linq;

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
            if (instance.UserCustomerId != 0) return false;
            Db.UserCustomers.Add(instance);
            Db.SaveChanges();
            return true;
        }

        public bool DeleteUserCustomer(int userCustomerId)
        {
            var instance = Db.UserCustomers.FirstOrDefault(p => p.UserCustomerId == userCustomerId);
            if (instance == null) return false;
            Db.UserCustomers.Remove(instance);
            Db.SaveChanges();
            return true;
        }

        public UserCustomer ReadUserCustomer(int userCustomerId)
        {
            var instance = Db.UserCustomers.FirstOrDefault(p => p.UserCustomerId == userCustomerId);
            return instance;
        }
        
    }
}