using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventor_Project.Models
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
        public Place PlaceOfStudy { get; set; }
        public Place PlaceOfLiving { get; set; }
        public List<Benefit> Benefits { get; set; }
        public virtual List<Role> Roles { get; set; }
        
    }
}