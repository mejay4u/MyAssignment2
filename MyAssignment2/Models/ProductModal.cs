using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyAssignment2.Models
{
    [Table("Products")]
    public class ProductModal
    {
        [Key]
        public int? ProductID { get; set; }

        [Required(ErrorMessage ="Please provide product name")]
        [Display(Name ="Product Name")]
        [MaxLength(50)]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Please provide product code")]
        [Display(Name = "Product Code")]
        [MaxLength(50)]
        public string ProductCode { get; set; }

        [Required(ErrorMessage = "Please provide product description")]
        [Display(Name = "Description")]
        [MaxLength(500)]
        public string ProductDescription { get; set; }

        [Required(ErrorMessage = "Please provide product price")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please provide product quantity")]
        [Display(Name = "Quantity")]
        public int ProductQty { get; set; }

        [Required(ErrorMessage = "Please provide contact name")]
        [Display(Name = "Contact Name")]
        [MaxLength(50)]
        public string ConatctName { get; set; }

        [Required(ErrorMessage = "Please provide Contact Email")]
        [Display(Name = "Product Code")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string ConatctEmail { get; set; }

        [Required(ErrorMessage = "Please provide contact telephone")]
        [Display(Name = "Telephone")]
        public int ContactTelephone { get; set; }

        public virtual ICollection<ProductImageModal> ImageDetails { get; set; }


    }
}