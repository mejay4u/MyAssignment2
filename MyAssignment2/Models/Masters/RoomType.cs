using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyAssignment2.Models.Masters
{
    public class RoomType
    {
        [Key]
        public Guid RoomTypeId { get; set; }

        [Required(ErrorMessage = "Please provide room type name")]
        [Display(Name = "Room Type Name")]
        public string RoomTypeName { get; set; }
    }
}