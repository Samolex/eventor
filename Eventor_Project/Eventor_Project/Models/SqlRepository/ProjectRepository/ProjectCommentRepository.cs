using Eventor_Project.Models.ProjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventor_Project.Models.SqlRepository
{
    public partial class SqlRepository
    {
        public IQueryable<ProjectComment> ProjectComments
        {
            get
            {
                return Db.ProjectComments;
            }
        }

        public bool CreateProjectComment(ProjectComment instance)
        {
            if (instance.ProjectCommentId == 0)
            {
                Db.ProjectComments.Add(instance);
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool UpdateProjectComment(ProjectComment instance)
        {
            ProjectComment cache = Db.ProjectComments.Where(p => p.ProjectCommentId == instance.ProjectCommentId).FirstOrDefault();
            if (cache != null)
            {
                //TODO : Update fields for ProjectComment
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool DeleteProjectComment(int ProjectCommentId)
        {
            ProjectComment instance = Db.ProjectComments.Where(p => p.ProjectCommentId == ProjectCommentId).FirstOrDefault();
            if (instance != null)
            {
                Db.ProjectComments.Remove(instance);
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public ProjectComment ReadProjectComment(int ProjectCommentId)
        {
            ProjectComment instance = Db.ProjectComments.Where(p => p.ProjectCommentId == ProjectCommentId).FirstOrDefault();
            return instance;
        }
        
    }
}