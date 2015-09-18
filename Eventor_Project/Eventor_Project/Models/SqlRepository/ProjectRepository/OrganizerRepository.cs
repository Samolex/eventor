using Eventor_Project.Models.ProjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventor_Project.Models.SqlRepository
{
    public partial class SqlRepository
    {


        public IQueryable<Organizer> Organisers
        {
            get
            {
                return Db.Organisers;
            }
        }

        public bool CreateOrganizer(Organizer instance)
        {
            if (instance.OrganizerId == 0)
            {
                Db.Organisers.Add(instance);
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool UpdateOrganizer(Organizer instance)
        {
            Organizer cache = Db.Organisers.Where(p => p.OrganizerId == instance.OrganizerId).FirstOrDefault();
            if (cache != null)
            {
                //TODO : Update fields for Organizer
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool DeleteOrganizer(int OrganizerId)
        {
            Organizer instance = Db.Organisers.Where(p => p.OrganizerId == OrganizerId).FirstOrDefault();
            if (instance != null)
            {
                Db.Organisers.Remove(instance);
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public Organizer ReadOrganizer(int OrganizerId)
        {
            Organizer instance = Db.Organisers.Where(p => p.OrganizerId == OrganizerId).FirstOrDefault();
            return instance;
        }
        
    }
}