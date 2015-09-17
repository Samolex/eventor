using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventor_Project.Models.ProjectModel.Relations
{
    public class UserMaterial
    {
        public int UserMaterialId { get; set; }
        public int UserId { get; set; }
        public int MaterialId { get; set; }
        public int Amount { get; set;}
    }
}