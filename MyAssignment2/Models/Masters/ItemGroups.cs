using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyAssignment2.Models.Masters
{
    [Table("ItemGroup")]
    public class ItemGroups
    {
      
        [Key]
        public Guid ItemGroupId { get; set; }

        [Required(ErrorMessage = "Please provide item group name")]
        [Display(Name = "Item Group Name:")]
        public string ItemGroupName { get; set; }
    }
}