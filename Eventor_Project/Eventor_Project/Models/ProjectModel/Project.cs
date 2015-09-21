using System;
using System.Collections.Generic;

namespace Eventor_Project.Models.ProjectModel
{ //TODO: Add "Attached files", Ratting, Private

    public class Project
    {
        public int ProjectId { get; set; }

        public int AuthorId { get; set; }
        public virtual User.User Author { get; set; }

        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }

        //TODO: This
        //public string CoverURL { get; set; }
        //public Bitmap Cover { get; set; }

        public string Headquarter { get; set; }
        public string Place { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }


        public DateTime OrganizationDate { get; set; }
        public DateTime EventDate { get; set; }


        public virtual ICollection<Organizer> Organisers { get; set; }
        public virtual ICollection<Material> Inventory { get; set; }
        public virtual ICollection<ProjectNews> News { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<ProjectComment> Comments { get; set; }
    }
}