using Eventor_Project.Models.ProjectModel.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eventor_Project.Models.ProjectModel
{   //TODO: Material on One User
    public class Material
    {
        public int MaterialId { get; set; }
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public string Title { get; set; }
        public int RequiredAmount { get; set; }
        public int CurrentAmount { 
            get {
                return 0;
            }
        }
        public virtual List<UserMaterial> UserMaterials { get; set; }

    }
}
    