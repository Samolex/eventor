using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventor_Project.Models.SqlRepository
{
    public partial class SqlRepository
    {


        public IQueryable<User.Benefit> Benefits
        {
            get
            {
                return Db.Benefits;
            }
        }

        public bool CreateBenefit(User.Benefit instance)
        {
            if (instance.BenefitId == 0)
            {
                Db.Benefits.Add(instance);
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool UpdateBenefit(User.Benefit instance)
        {
            User.Benefit cache = Db.Benefits.Where(p => p.BenefitId == instance.BenefitId).FirstOrDefault();
            if (cache != null)
            {
                cache.Code = instance.Code;
                cache.Name = instance.Name;
                cache.Users = instance.Users;
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool DeleteBenefit(int BenefitId)
        {
            User.Benefit instance = Db.Benefits.Where(p => p.BenefitId == BenefitId).FirstOrDefault();
            if (instance != null)
            {
                Db.Benefits.Remove(instance);
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public User.Benefit ReadBenefit(int BenefitId)
        {
            User.Benefit instance = Db.Benefits.Where(p => p.BenefitId == BenefitId).FirstOrDefault();
            return instance;
        }
        
    }
}