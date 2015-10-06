using System.Collections.Generic;
using Eventor_Project.Models.ProjectModel;
using Eventor_Project.Models.ProjectModel.Relations;
using System.ComponentModel.DataAnnotations;
using System;

namespace Eventor_Project.Models.User
{
    public class User
    {
        //TODO: Skills, Items, Photo, Avatar, Social networks
        [Key]
        public int UserId { get; set; }
        [Required, MaxLength(200), EmailAddress]
        public string Email { get; set; }
        [MaxLength(20)]
        public string Nickname { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Surname { get; set; }
        [MaxLength(50)]
        public string Patronymic { get; set; }
        [Required]
        public Sex Sex { get; set; }
        public virtual Place PlaceOfStudy { get; set; }
        public virtual Place PlaceOfLiving { get; set; }
        [MaxLength(200), EmailAddress]
        public string ContactEmail { get; set; }
        [MaxLength(50), Phone]
        public string PhoneNumber { get; set; }
        [Required, MaxLength(200)]
        public string Password { get; set; }
        public DateTime Birthdate { get; set; }
        public virtual ICollection<Benefit> Benefits { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<UserMaterial> Materials { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Organizer> Organizers { get; set; }
        public virtual ICollection<ProjectComment> Comments { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
