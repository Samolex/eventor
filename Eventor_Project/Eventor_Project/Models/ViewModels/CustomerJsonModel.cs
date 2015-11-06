using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventor_Project.Models.ViewModels
{
    public class CustomerJsonModel
    {
        public int CustomerId { get; set; }
        public int ProjectId { get; set; }

        public int MinCount { get; set; }
        public int MaxCount { get; set; }
        public string Role { get; set; }
        public string Description { get; set; }
    }
}