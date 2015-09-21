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

        #region Benefit

        IQueryable<User.Benefit> Benefits { get; }

        bool CreateBenefit(User.Benefit instance);

        bool UpdateBenefit(User.Benefit instance);

        bool DeleteBenefit(int BenefitId);
        User.Benefit ReadBenefit(int BenefitId);

        #endregion 

        #region Place

        IQueryable<User.Place> Places { get; }

        bool CreatePlace(User.Place instance);

        bool UpdatePlace(User.Place instance);

        bool DeletePlace(int PlaceId);

        User.Place ReadPlace(int PlaceId);

        #endregion 
        
        
    }
}
