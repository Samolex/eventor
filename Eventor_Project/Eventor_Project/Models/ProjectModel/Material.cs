﻿using System.Collections.Generic;
using System.Linq;
using Eventor_Project.Models.ProjectModel.Relations;

namespace Eventor_Project.Models.ProjectModel
{
    public class Material
    {
        public int MaterialId { get; set; }
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public int RequiredAmount { get; set; }

        public int CurrentAmount
        {
            get { return UserMaterials == null ? 0 : UserMaterials.Select(x => x.Amount).Sum(); }
        }

        public virtual Project Project { get; set; }
        public virtual ICollection<UserMaterial> UserMaterials { get; set; }
    }
}