using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventor_Project.Models.ProjectModel.Relations
{
    public class UserOrganizer
    {
        public int UserOrganizerId { get; set; }
        public int UserId { get; set; }
        public int OrganizerId { get; set; }

        public virtual User User { get; set; }
        public virtual Organizer Organizer { get; set; }
    }
}