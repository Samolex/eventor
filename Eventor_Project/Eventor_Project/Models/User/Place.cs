﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Eventor_Project.Models.User
{
    public class Place
    {
        public int PlaceId { get; set; }
        public string PlaceInfo { get; set; }

        [InverseProperty("PlaceOfLiving")]
        public ICollection<User> LivingUsers { get; set; }

        [InverseProperty("PlaceOfStudy")]
        public ICollection<User> StudyingUsers { get; set; }
    }
}