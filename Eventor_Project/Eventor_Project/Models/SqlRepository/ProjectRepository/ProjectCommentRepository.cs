using System.Linq;
using Eventor_Project.Models.ProjectModel;

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
            var cache = Db.ProjectComments.FirstOrDefault(p => p.ProjectCommentId == instance.ProjectCommentId);
            if (cache == null) return false;
            cache.Body = instance.Body;
            cache.Date = instance.Date;
            Db.SaveChanges();
            return true;
        }

        public bool DeleteProjectComment(int projectCommentId)
        {
            var instance = Db.ProjectComments.FirstOrDefault(p => p.ProjectCommentId == projectCommentId);
            if (instance == null) return false;
            Db.ProjectComments.Remove(instance);
            Db.SaveChanges();
            return true;
        }

        public ProjectComment ReadProjectComment(int projectCommentId)
        {
            var instance = Db.ProjectComments.FirstOrDefault(p => p.ProjectCommentId == projectCommentId);
            return instance;
        }
    }
}