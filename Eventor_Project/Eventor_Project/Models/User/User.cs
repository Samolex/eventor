using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventor_Project.Models.User
{
    public class User
    {
        //TODO: Skills, Items, Photo, Avatar, Social networks
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Nickname { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public Sex Sex { get; set; }
        public virtual Place PlaceOfStudy { get; set; }
        public virtual Place PlaceOfLiving { get; set; }
        public string ContactEmail { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ICollection<Benefit> Benefits { get; set; }
        public virtual ICollection<Role> Roles { get; set; }

    }
}