﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eventor_Project.Models.ProjectModel
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public int ProjectId { get; set; }

        public string Role { get; set; }
        [Required]
        public int MaxCount { get; set; }
        [Required]
        public int MinCount { get; set; }

        public virtual int CurrentCount
        {
            get {
                if (Customers != null)
                {
                    return Customers.Count;
                }
                else
                    return 0;
            }
        }

        public string Description { get; set; }


        public virtual Project Project { get; set; }
        public virtual ICollection<User.User> Customers { get; set; }
    }
}