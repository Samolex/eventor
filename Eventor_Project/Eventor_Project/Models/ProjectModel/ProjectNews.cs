using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eventor_Project.Models.ProjectModel
{
    public class ProjectNews
    {
        public int ProjectNewsId { get; set; }
        public int ProjectId { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public virtual Project Project { get; set; }

    }
}
