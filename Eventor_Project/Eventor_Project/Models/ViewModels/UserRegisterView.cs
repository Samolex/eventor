using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Eventor_Project.Models.User;

namespace Eventor_Project.Models.ViewModels
{
    public class UserRegisterView
    {
        public int UserId { get; set; }


        [Required(ErrorMessage = "Введите email"), EmailAddress, MaxLength(200, ErrorMessage = "Поле не може содержать более 200 символов"), DisplayName("E-mail")]
        public string Email { get; set; }


        [MaxLength(5000), DisplayName("Информация о пользователе")]
        public string About { get; set; }

        [Required(ErrorMessage = "Необходимо указать пароль"), DisplayName("Пароль")]
        public string Password { get; set; }



        [Compare("Password"), DisplayName("Подтверждение пароля")]
        public string ConfirmPassword { get; set; }

        [MaxLength(50, ErrorMessage = "Поле не може содержать более 50 символов"), DisplayName("Ник (псевдоним)")]
        public string Nickname { get; set; }


        [Required(ErrorMessage = "Введите имя"), MaxLength(50, ErrorMessage = "Поле не може содержать более 50 символов"), DisplayName("Имя")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Введите фамилию"), MaxLength(50, ErrorMessage = "Поле не може содержать более 50 символов"), DisplayName("Фамилия")]
        public string Surname { get; set; }


        [MaxLength(50, ErrorMessage = "Поле не може содержать более 50 символов"), DisplayName("Отчество")]
        public string Patronymic { get; set; }


        [Phone, MaxLength(50), DisplayName("Номер телефона")]
        public string PhoneNumber { get; set; }
    }
}