using System.Linq;
using Eventor_Project.Models.ProjectModel;
using System;

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
            try
            {
                if (instance.ProjectNewsId == 0)
                {
                    Db.ProjectNews.Add(instance);
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

        public bool UpdateProjectNews(ProjectNews instance)
        {
            try
            {
                ProjectNews news = Db.ProjectNews.Find(instance.ProjectNewsId);
                Type type = instance.GetType();

                foreach (var info in type.GetProperties())
                {
                    if(info.CanWrite)
                    {
                        var value = info.GetValue(instance);
                        if(value != null){
                            info.SetValue(news, value, null);
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

        public bool DeleteProjectNews(int projectNewsId)
        {
            try
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
            catch
            {
                return false;
            }
        }

        public ProjectNews ReadProjectNews(int projectNewsId)
        {
            var instance = Db.ProjectNews.FirstOrDefault(p => p.ProjectNewsId == projectNewsId);
            return instance;
        }
    }
}