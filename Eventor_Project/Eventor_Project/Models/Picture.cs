using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eventor_Project.Models
{
    public class Picture
    {
        [Key]
        public int PictureId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public byte[] Image { get; set; }
        [Required]
        public int OwnerId { get; set; }
    }
}