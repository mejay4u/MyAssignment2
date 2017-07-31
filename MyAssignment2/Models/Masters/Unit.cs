using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyAssignment2.Models.Masters
{
    public class Unit
    {
        [Key]
        public Guid UnitId { get; set; }

        [Required(ErrorMessage = "Please provide unit name")]
        [Display(Name = "Unit Name:")]
        public string UnitName { get; set; }
    }
}