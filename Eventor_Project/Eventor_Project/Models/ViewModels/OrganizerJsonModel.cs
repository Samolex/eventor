using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventor_Project.Models.ViewModels
{
    public class OrganizerJsonModel
    {
        public int OrganizerId { get; set; }
        public int ProjectId { get; set; }

        public string Name { get; set; }
        public int RequiredCount { get; set; }
        public string Description { get; set; }
    }
}