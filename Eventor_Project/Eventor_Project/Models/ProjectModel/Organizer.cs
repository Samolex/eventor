using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eventor_Project.Models.ProjectModel
{
    public class Organizer
    {
        public int OrganizerId { get; set; }
        public int ProjectId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int RequiredCount { get; set; }
        public string Description { get; set; }

        public virtual int CurrentCount
        {
            get
            {
                return Users != null ? Users.Count : 0;
            }
        }

        public virtual ICollection<User.User> Users { get; set; }
        public virtual Project Project { get; set; }
    }
}