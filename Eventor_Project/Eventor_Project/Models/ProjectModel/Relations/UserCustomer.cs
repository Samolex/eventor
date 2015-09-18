using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventor_Project.Models.ProjectModel.Relations
{
    public class UserCustomer
    {
        public int UserCustomerId { get; set; }
        public int UserId { get; set; }
        public int CustomerId { get; set; }

        public virtual User User { get; set; }
        public virtual Customer Customer { get; set; }
    }
}