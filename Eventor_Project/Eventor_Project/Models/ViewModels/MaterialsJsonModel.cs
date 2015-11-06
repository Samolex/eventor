using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventor_Project.Models.ViewModels
{
    public class MaterialsJsonModel
    {
        public int MaterialId { get; set; }
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public int RequiredAmount { get; set; }
    }
}