using System.Data;
using System.Linq;
using Eventor_Project.Models.ProjectModel;

namespace Eventor_Project.Models.SqlRepository
{
    public partial class SqlRepository
    {
        public IQueryable<Project> Projects
        {
            get { return Db.Projects; }
        }

        public bool CreateProject(Project instance)
        {
            if (instance.ProjectId == 0)
            {
                Db.Projects.Add(instance);
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool UpdateProject(Project instance)
        {
            var cache = Db.Projects.Where(p => p.ProjectId == instance.ProjectId).FirstOrDefault();
            if (instance != null)
            {
                cache.Title = instance.Title;
                cache.ShortDescription = instance.ShortDescription;
                cache.Description = instance.Description;
                cache.CategoryId = instance.CategoryId;
                cache.Headquarter = instance.Headquarter;
                cache.Place = instance.Place;
                cache.OrganizationDate = instance.OrganizationDate;
                cache.EventDate = instance.EventDate;
                cache.ChangeTime = instance.ChangeTime;
                
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool DeleteProject(int ProjectId)
        {
            var instance = Db.Projects.Where(p => p.ProjectId == ProjectId).FirstOrDefault();
            if (instance != null)
            {
                Db.Projects.Remove(instance);
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public Project ReadProject(int ProjectId)
        {
            var instance = Db.Projects.Where(p => p.ProjectId == ProjectId).FirstOrDefault();
            return instance;
        }
    }
}