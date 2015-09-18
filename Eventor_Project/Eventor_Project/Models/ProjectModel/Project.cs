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

        public int AuthorId { get; set; }
        public virtual User Author { get; set; }

        public string Title { get; set; }

        //public string CoverURL { get; set; }
        //public Bitmap Cover { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public string Headquarter { get; set; }
        public string Place { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual List<Organizer> Organisers { get; set; }
        public virtual List<Material> Inventory { get; set; }
        public virtual List<Money> Money { get; set; }

        public DateTime OrganizationDate { get; set; }

        public DateTime EventDate { get; set; }

        public virtual List<ProjectNews> News { get; set; }
        public virtual List<User> Users { get; set; }

        public virtual List<ProjectComment> Comments { get; set; }








    }
}