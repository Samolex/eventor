﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Eventor_Project.Models.ProjectModel
{ 
    //TODO: Add "Attached files", Ratting, Private
    public class Project
    {
        public int ProjectId { get; set; }
        [Required]
        public int AuthorId { get; set; }
        public virtual User.User Author { get; set; }

        [DisplayName("Заголовок")]
        public string Title { get; set; }
        [DisplayName("Короткое описание")]
        public string ShortDescription { get; set; }
        [DisplayName("Полное описание")]
        public string Description { get; set; }

        //TODO: This
        //public string CoverURL { get; set; }
        //public Bitmap Cover { get; set; }
        [DisplayName("Штаб-квартира")]
        public string Headquarter { get; set; }
        [DisplayName("Место проведения")]
        public string Place { get; set; }

        [DisplayName("Категория")]
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [DisplayName("Дата организации")]
        public DateTime? OrganizationDate { get; set; }
        [DisplayName("Дата проведения")]
        public DateTime? EventDate { get; set; }


        public virtual ICollection<Organizer> Organisers { get; set; }
        public virtual ICollection<Material> Inventory { get; set; }
        public virtual ICollection<ProjectNews> News { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<ProjectComment> Comments { get; set; }

        public virtual int OrganisersCurrentCount
        {
            get
            {
                return Organisers != null ? Organisers.Sum(m=>m.CurrentCount) : 0;
            }
        }

        public virtual int OrganisersRequiredCount
        {
            get
            {
                return Organisers != null ? Organisers.Sum(m => m.RequiredCount) : 0;
            }
        }

        public virtual int InventoryCurrentCount
        {
            get
            {
                return Inventory != null ? Inventory.Sum(m=>m.CurrentAmount) : 0;
            }
        }

        public virtual int InventoryRequiredCount
        {
            get
            {
                return Inventory != null ? Inventory.Sum(m => m.RequiredAmount) : 0;
            }
        }

        public virtual int CustomersCurrentCount
        {
            get
            {
                return Customers != null ? Customers.Sum(m=>m.CurrentCount) : 0;
            }
        }

        public virtual int CustomersRequiredCount
        {
            get
            {
                return Customers != null ? Customers.Sum(m=>m.MinCount) : 0;
            }
        }

        public DateTime AddedTime { get; set; }
        public DateTime ChangeTime { get; set; }
    }
}