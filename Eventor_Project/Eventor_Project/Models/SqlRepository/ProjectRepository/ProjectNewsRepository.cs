using System.Linq;
using Eventor_Project.Models.ProjectModel;

namespace Eventor_Project.Models.SqlRepository
{
    public partial class SqlRepository
    {
        public IQueryable<ProjectNews> ProjectNews
        {
            get { return Db.ProjectNews; }
        }

        public bool CreateProjectNews(ProjectNews instance)
        {
            if (instance.ProjectNewsId == 0)
            {
                Db.ProjectNews.Add(instance);
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool UpdateProjectNews(ProjectNews instance)
        {
            var cache = Db.ProjectNews.FirstOrDefault(p => p.ProjectNewsId == instance.ProjectNewsId);
            if (cache != null)
            {
                cache.Date = instance.Date;
                cache.Title = instance.Title;
                cache.Body = instance.Body;
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool DeleteProjectNews(int projectNewsId)
        {
            var instance = Db.ProjectNews.FirstOrDefault(p => p.ProjectNewsId == projectNewsId);
            if (instance != null)
            {
                Db.ProjectNews.Remove(instance);
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public ProjectNews ReadProjectNews(int projectNewsId)
        {
            var instance = Db.ProjectNews.FirstOrDefault(p => p.ProjectNewsId == projectNewsId);
            return instance;
        }
    }
}