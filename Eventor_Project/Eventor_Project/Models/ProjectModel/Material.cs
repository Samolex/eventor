using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eventor_Project.Models.ProjectModel
{
    public class Material
    {
        public int MaterialId { get; set; }
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public int RequiredAmount { get; set; }
        public int CurrentAmount { get; set; }
        public List<User> Helper { get; set; }

        public virtual Project Project { get; set; }
    }
}
    