using System.Data;
using System.Linq;
using Eventor_Project.Models.ProjectModel;
using System;

namespace Eventor_Project.Models.SqlRepository
{
    public partial class SqlRepository
    {
        public IQueryable<Project> Projects
        {
            get 
            { 
                return Db.Projects; 
            }
        }

        public bool CreateProject(Project instance)
        {
            try
            {
                if (instance.ProjectId == 0)
                {
                    Db.Projects.Add(instance);
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

        public bool UpdateProject(Project instance)
        {
            try
            {
                Project project = Db.Projects.Find(instance.ProjectId);
                Type type = instance.GetType();

                foreach (var info in type.GetProperties())
                {
                    if (info.CanWrite)
                    {
                        var value = info.GetValue(instance);
                        if (value != null)
                        {
                            info.SetValue(project, value, null);
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

        public bool DeleteProject(int ProjectId)
        {
            try
            {
                var instance = Db.Projects.FirstOrDefault(p => p.ProjectId == ProjectId);
                if (instance != null)
                {
                    Db.Projects.Remove(instance);
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

        public Project ReadProject(int ProjectId)
        {
            var instance = Db.Projects.FirstOrDefault(p => p.ProjectId == ProjectId);
            return instance;
        }
    }
}