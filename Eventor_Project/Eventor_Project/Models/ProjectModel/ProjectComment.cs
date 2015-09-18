using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eventor_Project.Models.ProjectModel
{
    public class ProjectComment
    {
        public int ProjectCommentId { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string Body { get; set; }

        public virtual Project Project { get; set; }
        public virtual User Author { get; set; }
    }
}
