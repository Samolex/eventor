using System.Linq;
using Eventor_Project.Models.ProjectModel;

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
            var cache = Db.Organisers.FirstOrDefault(p => p.OrganizerId == instance.OrganizerId);
            if (cache == null) return false;
            cache.Name = instance.Name;
            cache.Description = instance.Description;
            Db.SaveChanges();
            return true;
        }

        public bool DeleteOrganizer(int organizerId)
        {
            var instance = Db.Organisers.FirstOrDefault(p => p.OrganizerId == organizerId);
            if (instance == null) return false;
            Db.Organisers.Remove(instance);
            Db.SaveChanges();
            return true;
        }

        public Organizer ReadOrganizer(int organizerId)
        {
            var instance = Db.Organisers.FirstOrDefault(p => p.OrganizerId == organizerId);
            return instance;
        }
    }
}