using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eventor_Project.Models.ProjectModel
{ //TODO: Add "Attached files", Ratting, Private

    public class Project
    {
        public int ProjectId { get; set; }

        public int AuthorId { get; set; }
        public virtual User.User Author { get; set; }

        [MaxLength(50), MinLength(10), Required]
        public string Title { get; set; }
        [Required, MaxLength(150)]
        public string ShortDescription { get; set; }
        public string Description { get; set; }

        //TODO: This
        //public string CoverURL { get; set; }
        //public Bitmap Cover { get; set; }

        [Required]
        public string Headquarter { get; set; }
        [Required]
        public string Place { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [Required]
        public DateTime OrganizationDate { get; set; }
        [Required]
        public DateTime EventDate { get; set; }


        public virtual ICollection<Organizer> Organisers { get; set; }
        public virtual ICollection<Material> Inventory { get; set; }
        public virtual ICollection<ProjectNews> News { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<ProjectComment> Comments { get; set; }

        public DateTime AddedTime { get; set; }
        public DateTime ChangeTime { get; set; }
    }
}