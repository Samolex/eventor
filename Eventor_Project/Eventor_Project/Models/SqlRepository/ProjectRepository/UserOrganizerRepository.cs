using Eventor_Project.Models.ProjectModel.Relations;
using System.Linq;

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
            if (instance.UserOrganizerId != 0) return false;
            Db.UserOrganizers.Add(instance);
            Db.SaveChanges();
            return true;
        }


        public bool DeleteUserOrganizer(int userOrganizerId)
        {
            var instance = Db.UserOrganizers.FirstOrDefault(p => p.UserOrganizerId == userOrganizerId);
            if (instance == null) return false;
            Db.UserOrganizers.Remove(instance);
            Db.SaveChanges();
            return true;
        }

        public UserOrganizer ReadUserOrganizer(int userOrganizerId)
        {
            var instance = Db.UserOrganizers.FirstOrDefault(p => p.UserOrganizerId == userOrganizerId);
            return instance;
        }
        
    }
}