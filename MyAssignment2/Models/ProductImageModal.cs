using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyAssignment2.Models
{
    [Table("ProductImages")]
    public class ProductImageModal
    {
        [Key]
        public int ImageId { get; set; }
        public string ImageUrl { get; set; }
       public int? ProductId { get; set; }
        public byte[] Image { get; set; }
    }
}