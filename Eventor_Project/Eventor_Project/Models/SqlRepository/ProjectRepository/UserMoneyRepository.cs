using Eventor_Project.Models.ProjectModel.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventor_Project.Models.SqlRepository
{
    public partial class SqlRepository
    {


        public IQueryable<UserMoney> UserMoneys
        {
            get
            {
                return Db.UserMoney;
            }
        }

        public bool CreateUserMoney(UserMoney instance)
        {
            if (instance.UserMoneyId == 0)
            {
                Db.UserMoney.Add(instance);
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool UpdateUserMoney(UserMoney instance)
        {
            UserMoney cache = Db.UserMoney.Where(p => p.UserMoneyId == instance.UserMoneyId).FirstOrDefault();
            if (cache != null)
            {
                //TODO : Update fields for UserMoney
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool DeleteUserMoney(int UserMoneyId)
        {
            UserMoney instance = Db.UserMoney.Where(p => p.UserMoneyId == UserMoneyId).FirstOrDefault();
            if (instance != null)
            {
                Db.UserMoney.Remove(instance);
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public UserMoney ReadUserMoney(int UserMoneyId)
        {
            UserMoney instance = Db.UserMoney.Where(p => p.UserMoneyId == UserMoneyId).FirstOrDefault();
            return instance;
        }
        
    }
}