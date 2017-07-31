using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyAssignment2.Models.Masters
{
    public class Rooms
    {
        [Key]
        public Guid RoomId { get; set; }

        [Required(ErrorMessage = "Please provide room name")]
        [Display(Name = "Room Name")]
        public string RoomNo { get; set; }

        [Required(ErrorMessage = "Please provide room type")]
        public Guid RoomTypeId { get; set; }

        [NotMapped]
        public virtual List<SelectListItem> RoomsTypeList { get; set; }

        public virtual RoomType RoomType { get; set; }
    }
}