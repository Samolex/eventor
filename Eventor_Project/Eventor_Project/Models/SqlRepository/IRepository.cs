using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventor_Project.Models.SqlRepository
{
    public interface IRepository
    {
        IQueryable<User.Role> Roles { get; }
        bool CreateRole(User.Role instance);
        bool UpdateRole(User.Role instance);
        bool DeleteRole(int RoleId);
        bool ReadRole(int RoleId);
    }
}
