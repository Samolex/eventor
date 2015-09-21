using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventor_Project.Models.SqlRepository
{
    public partial class SqlRepository
    {
        public IQueryable<User.Place> Places
        {
            get
            {
                return Db.Places;
            }
        }

        public bool CreatePlace(User.Place instance)
        {
            if (instance.PlaceId == 0)
            {
                Db.Places.Add(instance);
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool UpdatePlace(User.Place instance)
        {
            User.Place cache = Db.Places.Where(p => p.PlaceId == instance.PlaceId).FirstOrDefault();
            if (cache != null)
            {
                cache.PlaceInfo = instance.PlaceInfo;
                cache.StudyingUsers = instance.StudyingUsers;
                cache.LivingUsers = instance.LivingUsers;
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool DeletePlace(int PlaceId)
        {
            User.Place instance = Db.Places.Where(p => p.PlaceId == PlaceId).FirstOrDefault();
            if (instance != null)
            {
                Db.Places.Remove(instance);
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public User.Place ReadPlace(int PlaceId)
        {
            User.Place instance = Db.Places.Where(p => p.PlaceId == PlaceId).FirstOrDefault();
            return instance;
        }
        
    }
}