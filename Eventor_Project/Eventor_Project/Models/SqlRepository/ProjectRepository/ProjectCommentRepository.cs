using System.Linq;
using Eventor_Project.Models.ProjectModel;
using System;

namespace Eventor_Project.Models.SqlRepository
{
    public partial class SqlRepository
    {
        public IQueryable<ProjectComment> ProjectComments
        {
            get { return Db.ProjectComments; }
        }

        public bool CreateProjectComment(ProjectComment instance)
        {
            try
            {
                if (instance.ProjectCommentId == 0)
                {
                    Db.ProjectComments.Add(instance);
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

        public bool UpdateProjectComment(ProjectComment instance)
        {
            try
            {
                ProjectComment comment = Db.ProjectComments.Find(instance.ProjectCommentId);
                Type type = comment.GetType();
                foreach(var info in type.GetProperties())
                {
                    if(info.CanWrite)
                    {
                        var value = info.GetValue(instance);
                        if(value != null)
                        {
                            info.SetValue(comment, value, null);
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

        public bool DeleteProjectComment(int projectCommentId)
        {
            try
            {
                var instance = Db.ProjectComments.FirstOrDefault(p => p.ProjectCommentId == projectCommentId);
                if (instance == null) return false;
                Db.ProjectComments.Remove(instance);
                Db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public ProjectComment ReadProjectComment(int projectCommentId)
        {
            var instance = Db.ProjectComments.FirstOrDefault(p => p.ProjectCommentId == projectCommentId);
            return instance;
        }
    }
}