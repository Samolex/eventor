﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventor_Project.Models.User
{
    public class Benefit
    {
        public int BenefitId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}