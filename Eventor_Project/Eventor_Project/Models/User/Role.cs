
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eventor_Project.Models.User
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        [MaxLength(50), Required]
        public string Code { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
   }
}
