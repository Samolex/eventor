using Eventor_Project.Models.ProjectModel.Relations;
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
        public int CurrentAmount { 
            get
            {
                return UserMaterials == null ? 0 : UserMaterials.Select(x => x.Amount).Sum();
            }
        }

        public virtual Project Project { get; set; }
        public virtual List<UserMaterial> UserMaterials { get; set; }

    }
}
    