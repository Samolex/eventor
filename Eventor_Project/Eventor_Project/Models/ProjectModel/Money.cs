using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eventor_Project.Models.ProjectModel
{
    public class Money
    {
        public int MoneyId { get; set; }
        public int ProjectId { get; set; }
        public int Title { get; set; }
        public int RequiredAmount { get; set; }
        public int CurrentAmount { get; set; }

        public virtual List<User> Sponsors { get; set; }
        public virtual Project Project { get; set; }

    }
}
