using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventor_Project.Models.SqlRepository
{
    public interface IRepository
    {

        #region Role

        IQueryable<User.Role> Roles { get; }

        bool CreateRole(User.Role instance);

        bool UpdateRole(User.Role instance);

        bool DeleteRole(int RoleId);

        User.Role ReadRole(int RoleId);

        #endregion

        #region User

        IQueryable<User.User> Users { get; }

        bool CreateUser(User.User instance);

        bool UpdateUser(User.User instance);

        bool DeleteUser(int UserId);

        User.User ReadUser(int UserId);

        #endregion 

        #region UserRole

        IQueryable<User.UserRole> UserRoles { get; }

        bool CreateUserRole(User.UserRole instance);

        bool UpdateUserRole(User.UserRole instance);

        bool DeleteUserRole(int UserRoleId);

        User.UserRole ReadUserRole(int UserRoleId);

        #endregion 
        
        
    }
}
