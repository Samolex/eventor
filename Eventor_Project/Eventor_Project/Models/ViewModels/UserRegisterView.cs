using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eventor_Project.Models.ViewModels
{
    public class UserRegisterView
    {
        public int UserId { get; set; }


        [Required(ErrorMessage = "Введите email"), EmailAddress, MaxLength(200, ErrorMessage = "Поле не може содержать более 200 символов")]
        public string Email { get; set; }



        public string Password { get; set; }


        [Compare("Password", ErrorMessage = "Пароли должны совпадать")]
        public string ConfirmPassword { get; set; }


        public DateTime Birthdate { get; set; }


        [MaxLength(10, ErrorMessage = "Поле не може содержать более 10 символов")]
        public string Captcha { get; set; }


        [MaxLength(50, ErrorMessage = "Поле не може содержать более 50 символов")]
        public string Nickname { get; set; }


        [Required(ErrorMessage = "Введите имя"), MaxLength(50, ErrorMessage = "Поле не може содержать более 50 символов")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Введите фамилию"), MaxLength(50, ErrorMessage = "Поле не може содержать более 50 символов")]
        public string Surname { get; set; }


        [MaxLength(50, ErrorMessage = "Поле не може содержать более 50 символов")]
        public string Patronymic { get; set; }


        [Required(ErrorMessage = "Укажите ваш пол")]
        public User.Sex Sex { get; set; }


        [EmailAddress, MaxLength(200, ErrorMessage = "Поле не може содержать более 200 символов")]
        public string ContactEmail { get; set; }


        [Phone, MaxLength(50)]
        public string PhoneNumber { get; set; }

        public IEnumerable<User.Sex> SexOptions =
            new List<User.Sex>
            {
                User.Sex.Male,
                User.Sex.Female,
            };
    }
}