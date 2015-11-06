using System.Collections.Generic;
using Eventor_Project.Models.ProjectModel;
using Eventor_Project.Models.ProjectModel.Relations;
using System.ComponentModel.DataAnnotations;
using System;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Eventor_Project.Models.SqlRepository;
using Eventor_Project.Models.User;
using Ninject;

namespace Eventor_Project.Models.ViewModels
{
    public class MessageView
    {
        [Key]
        public int MessageId { get; set; }

        [Required(ErrorMessage = "Потерян отправитель письма")]
        public int SenderId { get; set; }

        [Required(ErrorMessage = "Потерян получатель письма")]
        public int ReceiverId { get; set; }

        [Required, MaxLength(500)]
        public string ReceiverNick { get; set; }

        [Required, MaxLength(500)]
        public string SenderNick { get; set; }
        [Required(ErrorMessage = "Введите тему сообщения"), MaxLength(100, ErrorMessage = "СЛишком длинная тема (более 100 символов)")]
        public string Topic { get; set; }

        [Required(ErrorMessage = "Введите текст сообщения"), MaxLength(5000, ErrorMessage = "Слишком длинное сообщения (более 5000 символов)")]
        public string Text { get; set; }
        public Message PrevMessage { get; set; }



    }
}
