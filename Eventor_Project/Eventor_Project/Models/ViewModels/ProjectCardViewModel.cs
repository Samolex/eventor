using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Eventor_Project.Models.ProjectModel;

namespace Eventor_Project.Models.ViewModels
{
    //TODO: Add "Attached files", Ratting, Private
    public class ProjectCardViewModel
    {
        public int ProjectId { get; set; }
        public int AuthorId { get; set; }

        public string Title { get; set; }
        public string GetTitle
        {
            get
            {
                return Title != null ? Title : "Неизвестный проект";
            }
        }
        public string ShortDescription { get; set; }
        public string Description { get; set; }

        public string Headquarter { get; set; }
        public string Place { get; set; }

        public int? CategoryId { get; set; }

        public DateTime? OrganizationDate { get; set; }
        public DateTime? EventDate { get; set; }
        public virtual string GetEventDate
        {
            get
            {
                return EventDate != null ? EventDate.Value.ToShortDateString() : "";
            }
        }


        public List<Organizer> Organisers { get; set; }
        public List<Material> Inventory { get; set; }
        public List<ProjectNews> News { get; set; }
        public List<Customer> Customers { get; set; }
        public List<ProjectComment> Comments { get; set; }

        public virtual int OrganisersCurrentCount
        {
            get
            {
                return Organisers != null ? Organisers.Sum(m => m.CurrentCount) : 0;
            }
        }

        public virtual int OrganisersRequiredCount
        {
            get
            {
                return Organisers != null ? Organisers.Sum(m => m.RequiredCount) : 0;
            }
        }

        public virtual int OrganisersCurrentPercents
        {
            get
            {
                return OrganisersRequiredCount != 0 ? (int)((OrganisersCurrentCount / (float)OrganisersRequiredCount) * 100) : 100;
            }
        }

        public virtual int InventoryCurrentCount
        {
            get
            {
                return Inventory != null ? Inventory.Sum(m => m.CurrentAmount) : 0;
            }
        }

        public virtual int InventoryNeedfulCount
        {
            get
            {
                return Inventory != null ? Inventory.Sum(m => m.NeedfulAmount) : 0;
            }
        }

        public virtual int InventoryRequiredCount
        {
            get
            {
                return Inventory != null ? Inventory.Sum(m => m.RequiredAmount) : 0;
            }
        }

        public virtual int InventoryNeedfulPercents
        {
            get
            {
                return InventoryRequiredCount != 0 ? (int)((InventoryNeedfulCount / (float)InventoryRequiredCount) * 100) : 100;
            }
        }

        public virtual int CustomersCurrentCount
        {
            get
            {
                return Customers != null ? Customers.Sum(m => m.CurrentCount) : 0;
            }
        }

        public virtual int CustomersRequiredCount
        {
            get
            {
                return Customers != null ? Customers.Sum(m => m.MinCount) : 0;
            }
        }
        public virtual int CustomersCurrentPercents
        {
            get
            {
                return CustomersRequiredCount != 0 ? (int)((CustomersCurrentCount / (float)CustomersRequiredCount) * 100) : 100;
            }
        }
        public DateTime AddedTime { get; set; }
        public DateTime ChangeTime { get; set; }
    }
}
