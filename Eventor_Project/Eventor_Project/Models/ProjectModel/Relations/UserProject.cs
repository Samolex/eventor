using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventor_Project.Models.ProjectModel.Relations
{
    public class UserProject
    {
        public int UserProjectId { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public TypeAttitude Attitude { get; set; }
    }
}