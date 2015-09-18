using Eventor_Project.Models.ProjectModel.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventor_Project.Models.SqlRepository
{
    public partial class SqlRepository
    {
        public IQueryable<UserProject> UserProject
        {
            get
            {
                return Db.UserProject;
            }
        }

        public bool CreateUserProject(UserProject instance)
        {
            if (instance.UserProjectId == 0)
            {
                Db.UserProject.Add(instance);
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool UpdateUserProject(UserProject instance)
        {
            UserProject cache = Db.UserProject.Where(p => p.UserProjectId == instance.UserProjectId).FirstOrDefault();
            if (cache != null)
            {
                //TODO : Update fields for UserProject
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool DeleteUserProject(int UserProjectId)
        {
            UserProject instance = Db.UserProject.Where(p => p.UserProjectId == UserProjectId).FirstOrDefault();
            if (instance != null)
            {
                Db.UserProject.Remove(instance);
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public UserProject ReadUserProject(int UserProjectId)
        {
            UserProject instance = Db.UserProject.Where(p => p.UserProjectId == UserProjectId).FirstOrDefault();
            return instance;
        }
        
    }
}