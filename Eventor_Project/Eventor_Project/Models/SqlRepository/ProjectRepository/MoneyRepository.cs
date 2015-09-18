using Eventor_Project.Models.ProjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventor_Project.Models.SqlRepository
{
    public partial class SqlRepository
    {

        public IQueryable<Money> Moneys
        {
            get
            {
                return Db.Moneys;
            }
        }

        public bool CreateMoney(Money instance)
        {
            if (instance.MoneyId == 0)
            {
                Db.Moneys.Add(instance);
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool UpdateMoney(Money instance)
        {
            Money cache = Db.Moneys.Where(p => p.MoneyId == instance.MoneyId).FirstOrDefault();
            if (cache != null)
            {
                //TODO : Update fields for Money
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool DeleteMoney(int MoneyId)
        {
            Money instance = Db.Moneys.Where(p => p.MoneyId == MoneyId).FirstOrDefault();
            if (instance != null)
            {
                Db.Moneys.Remove(instance);
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public Money ReadMoney(int MoneyId)
        {
            Money instance = Db.Moneys.Where(p => p.MoneyId == MoneyId).FirstOrDefault();
            return instance;
        }
        
    }
}