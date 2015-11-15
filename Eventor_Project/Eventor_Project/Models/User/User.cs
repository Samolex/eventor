using System.Collections.Generic;
using Eventor_Project.Models.ProjectModel;
using Eventor_Project.Models.ProjectModel.Relations;
using System.ComponentModel.DataAnnotations;
using System;
using System.Linq;
using System.ComponentModel;
namespace Eventor_Project.Models.User
{
    public class User
    {
        #region private fields
        private string nickname;
        private string contactEmail;
        private string about;
        #endregion
        //TODO: Skills, Items, Photo, Avatar, Social networks

        [Key]
        public int UserId { get; set; }
        [Required, MaxLength(200), EmailAddress]
        public string Email { get; set; }
        [MaxLength(20), DisplayName("Псевдоним")]
        public string Nickname { 
            get {
                if (String.IsNullOrEmpty(nickname))
                    return Name + " " + Surname;
                else return nickname;
            } 
            set { nickname = value; } 
        }

        public string Nickname2
        {
            get
            {
                if (String.IsNullOrEmpty(nickname))
                    return "Не указан";
                else return nickname;
            }
        }
        [Required, MaxLength(50), DisplayName("Имя")]
        public string Name { get; set; }
        [MaxLength(50), DisplayName("Фамилия")]
        public string Surname { get; set; }
        [MaxLength(50), DisplayName("Отчество")]
        public string Patronymic { get; set; }
        [Required, DisplayName("Пол")]
        public Sex Sex { get; set; }
        [DisplayName("Место учёбы")]
        public virtual Place PlaceOfStudy { get; set; }
        [DisplayName("Место проживания")]
        public virtual Place PlaceOfLiving { get; set; }
        [MaxLength(200), EmailAddress, DisplayName("E-mail")]
        public string ContactEmail {
            get
            {
                if (contactEmail == null)
                    return Email;
                else
                    return contactEmail;
            }
            set { contactEmail = value; }
        }
        [MaxLength(50), Phone, DisplayName("Телефон")]
        public string PhoneNumber { get; set; }
        [Required, MaxLength(200), DisplayName("Пароль")]
        public string Password { get; set; }

        [MaxLength(5000), DisplayName("Информация о пользователе")]
        public string About {
            get
            {
                return String.IsNullOrEmpty(about) ? "Данный пользователь пока не указал о себе никакой дополнительной информации" : about;
            }
            set { about = value; }}
        [DisplayName("Дата рождения")]
        public DateTime Birthdate { get; set; }
        [DisplayName("Привилегии")]
        public virtual ICollection<Benefit> Benefits { get; set; }
        [DisplayName("Роли")]
        public virtual ICollection<Role> Roles { get; set; }
        [DisplayName("Материалы")]
        public virtual ICollection<UserMaterial> Materials { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Organizer> Organizers { get; set; }
        public virtual ICollection<ProjectComment> Comments { get; set; }
        public virtual ICollection<Project> Projects { get; set; }


        public bool InRoles(string roles)
        {
            if (string.IsNullOrWhiteSpace(roles))
            {
                return false;
            }

            var rolesArray = roles.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var role in rolesArray)
            {
                var hasRole = Roles.Any(p => string.Compare(p.Code, role, true) == 0);
                if (hasRole)
                {
                    return true;
                }
            }
            return false;
        }

        public string DisplayBirthdate
        {
            get
            {
                return Birthdate.ToString("dd MMMM yyyy");
            }
        }


    }
}
