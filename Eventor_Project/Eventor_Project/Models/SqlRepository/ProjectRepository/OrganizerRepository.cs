using System.Linq;
using Eventor_Project.Models.ProjectModel;
using System;

namespace Eventor_Project.Models.SqlRepository
{
    public partial class SqlRepository
    {
        public IQueryable<Organizer> Organisers
        {
            get { return Db.Organisers; }
        }

        public bool CreateOrganizer(Organizer instance)
        {
            try
            {
                if (instance.OrganizerId == 0)
                {
                    Db.Organisers.Add(instance);
                    Db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateOrganizer(Organizer instance)
        {
            try
            {
                Organizer organizer = Db.Organisers.Find(instance.OrganizerId);
                Type type = instance.GetType();

                foreach(var info in type.GetProperties())
                {
                    if(info.CanWrite)
                    {
                        var value = info.GetValue(instance);
                        if(value != null)
                        {
                            info.SetValue(organizer, value, null);
                        }
                    }
                }
                Db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteOrganizer(int organizerId)
        {
            try
            {
                var instance = Db.Organisers.FirstOrDefault(p => p.OrganizerId == organizerId);
                if (instance == null) return false;
                Db.Organisers.Remove(instance);
                Db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Organizer ReadOrganizer(int organizerId)
        {
            var instance = Db.Organisers.FirstOrDefault(p => p.OrganizerId == organizerId);
            return instance;
        }
    }
}