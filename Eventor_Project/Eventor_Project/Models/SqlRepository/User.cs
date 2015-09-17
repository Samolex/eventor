using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventor_Project.Models.SqlRepository
{
    public partial class SqlRepository
    {
        public IQueryable<User.User> Users
        {
            get
            {
                return Db.Users;
            }
        }

        public bool CreateUser(User.User instance)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(User.User instance)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(int UserId)
        {
            throw new NotImplementedException();
        }

        public bool ReadUser(int UserId)
        {
            throw new NotImplementedException();
        }
    }
}
