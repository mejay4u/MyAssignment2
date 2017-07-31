using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyAssignment2.Models.Masters
{
    [Table("Table")]
    public class Tables
    {
        [Key]
        public Guid TableId { get; set; }

        [Required(ErrorMessage = "Please provide table name")]
        [Display(Name = "Table Name")]
        public string TableName { get; set; }

      
        [Display(Name = "Capacity")]
        public int? Capacity { get; set; }
    }
}