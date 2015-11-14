 using System.ComponentModel.DataAnnotations;

namespace Eventor_Project.Models.ProjectModel
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}