using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyAssignment2.Models.Masters
{
    [Table("Item")]
    public class Items
    {
        [Key]
        public Guid ItemId { get; set; }

        [Required(ErrorMessage = "Please provide item name")]
        [Display(Name = "Item Name:")]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "Please provide item code")]
        [Display(Name = "Item Code:")]
        public int? ItemCode  { get; set; }

        [Required(ErrorMessage = "Please provide unit")]
        [Display(Name = "Unit:")]
        public Guid UnitId { get; set; }

        [Required(ErrorMessage = "Please provide item group")]
        [Display(Name = "Item Group:")]
        public Guid ItemGroupId { get; set; }

        [Required(ErrorMessage = "Please provide room price")]
        [Display(Name = "Room Price:")]
        public decimal RoomRate { get; set; }

        [Required(ErrorMessage = "Please provide table price")]
        [Display(Name = "Table Price:")]
        public decimal TableRate { get; set; }

        [NotMapped]
        public List<SelectListItem> UnitsList { get; set; }

        [NotMapped]
        public List<SelectListItem> ItemGroupList { get; set; }

        public virtual ItemGroups ItemGroups { get; set; }
        public virtual Unit Unit { get; set; }
        
         
    }
}