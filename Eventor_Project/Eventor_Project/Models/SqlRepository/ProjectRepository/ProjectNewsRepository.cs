using Eventor_Project.Models.ProjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventor_Project.Models.SqlRepository
{
    public partial class SqlRepository
    {

        public IQueryable<ProjectNews> ProjectNews
        {
            get
            {
                return Db.ProjectNews;
            }
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
            ProjectNews cache = Db.ProjectNews.Where(p => p.ProjectNewsId == instance.ProjectNewsId).FirstOrDefault();
            if (cache != null)
            {
                //TODO : Update fields for ProjectNews
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool DeleteProjectNews(int ProjectNewsId)
        {
            ProjectNews instance = Db.ProjectNews.Where(p => p.ProjectNewsId == ProjectNewsId).FirstOrDefault();
            if (instance != null)
            {
                Db.ProjectNews.Remove(instance);
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public ProjectNews ReadProjectNews(int ProjectNewsId)
        {
            ProjectNews instance = Db.ProjectNews.Where(p => p.ProjectNewsId == ProjectNewsId).FirstOrDefault();
            return instance;
        }
        
    }
}