using System.ComponentModel.DataAnnotations;

namespace Eventor_Project.Models.ProjectModel.Relations
{
    public class UserMaterial
    {
        [Key]
        public int UserId { get; set; }
        public virtual User.User User { get; set; }
        [Key]
        public int MaterialId { get; set; }
        public virtual Material Material { get; set; }
        [Required]
        public int Amount { get; set; }
    }
}