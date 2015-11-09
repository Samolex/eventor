using System.Collections.Generic;
using Eventor_Project.Models.ProjectModel;
using Eventor_Project.Models.ProjectModel.Relations;
using System.ComponentModel.DataAnnotations;
using System;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Eventor_Project.Models.SqlRepository;
using Ninject;

namespace Eventor_Project.Models.User
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        [Required]
        public int ReceiverId { get; set; }

        [Required]
        public int SenderId { get; set; }

        public int? PrevMessageId { get; set; }

        [Required]
        public string ReceiverNick { get; set; }

        [Required]
        public string SenderNick { get; set; }

        [Required, MaxLength(100)]
        public string Topic { get; set; }

        [Required, MaxLength(5000)]
        public string Text { get; set; }

        [DisplayName("Время отправления")]
        public DateTime DepartureTime { get; set; }

    }
}
