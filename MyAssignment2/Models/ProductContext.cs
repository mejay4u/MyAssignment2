using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyAssignment2.Models
{
    public class ProductContext:DbContext
    {
        public ProductContext()
            :base("name=DefaultConnection")
        {

        }
        public DbSet<ProductModal> Products { get; set; }
        public DbSet<ProductImageModal> ProductImages { get; set; }
    }
}