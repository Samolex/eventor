using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventor_Project.Models.ProjectModel.Relations
{
    public class UserMoney
    {
        public int UserMoneyId { get; set; }
        public int UserId { get; set; }
        public int MoneyId { get; set; }
        public int Ammount { get; set; }
    }
}