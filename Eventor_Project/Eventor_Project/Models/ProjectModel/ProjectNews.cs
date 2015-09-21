using System;
using System.ComponentModel.DataAnnotations;

namespace Eventor_Project.Models.ProjectModel
{
    public class ProjectNews
    {
        public int ProjectNewsId { get; set; }
        public int ProjectId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }

        public virtual Project Project { get; set; }
    }
}