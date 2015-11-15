using System.Linq;
using Eventor_Project.Models.ProjectModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;

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

        public void SaveOrganisers(List<Organizer> organisers)
        {
            var projectId = organisers.FirstOrDefault().ProjectId;
            var project = ReadProject(projectId);
            var was = project.Organisers.ToList();
            foreach (var organiser in was.Where(o => organisers.All(n => n.OrganizerId != o.OrganizerId)))
            {
                DeleteOrganizer(organiser.OrganizerId);
            }
            foreach (var organiser in organisers)
            {
                if (organiser.OrganizerId == 0)
                    Db.Organisers.Add(organiser);
                else
                    UpdateOrganizer(organiser);
            }
            Db.SaveChanges();

        }
    }
}