using Eventor_Project.Models.ProjectModel.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eventor_Project.Models.ProjectModel
{   //TODO: Null User
    public class Organizer
    {
        public int OrganizerId { get; set; }
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual List<UserOrganizer> Users { get; set; }
        public virtual Project Project { get; set; }

    }
}
