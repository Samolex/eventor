using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eventor_Project.Models.ProjectModel
{
    public class Organizer
    {
        public int OrganizerId { get; set; }
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
        public virtual Project Project { get; set; }

    }
}
