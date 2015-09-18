
using Eventor_Project.Models.ProjectModel.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventor_Project.Models.ProjectModel
{
    public class Customer
    {

        public int CustomerId { get; set; }
        public int ProjectId { get; set; }

        public string Role { get; set; }
        public int MaxCount { get; set; }
        public int MinCount { get; set; }
        public int CurrentCount
        {
            get { return Customers.Count; }
        }

        public string Description { get; set; }


        public virtual Project Project { get; set; }
        public virtual List<UserCustomer> Customers { get; set; }

    }
}