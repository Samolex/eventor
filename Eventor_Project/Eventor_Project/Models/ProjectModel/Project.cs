using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Eventor_Project.Models.ProjectModel
{   //TODO: Add "Attached files", Ratting, Private
    public class Project
    {
        public int ProjectId { get; set; }

        //public int AuthorId { get; set; }
        //public User Author { get; set; }

        public string Title { get; set; }

        //public string CoverURL { get; set; }
        //public Bitmap Cover { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; }

        //public int CategoryId { get; set; }
        //public Category Category { get; set; }

        public List<Organizer> Organisers { get; set; }
        public List<Material> Inventory { get; set;}
        public List<Money> Money { get; set; }
        public List<Member> Members { get; set; }

        public DateTime OrganizationDate { get; set; }

        public DateTime EventDate { get; set; }

        public List<ProjectNews> News { get; set; }
        public List<User> Users { get; set; }

        public List<ProjectComment> Comments { get; set; }








    }
}