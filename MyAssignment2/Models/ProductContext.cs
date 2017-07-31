using MyAssignment2.Models.Entries;
using MyAssignment2.Models.Masters;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyAssignment2.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext()
            : base("name=DefaultConnection")
        {

        }
        public DbSet<ProductModal> Products { get; set; }
        public DbSet<ProductImageModal> ProductImages { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<ItemGroups> ItemGroups { get; set; }
        public DbSet<Items> Items { get; set; }

        public DbSet<Tables> Tables { get; set; }

        public DbSet<RoomType> RoomTypes { get; set; }

        public DbSet<Rooms> Rooms { get; set; }

        public DbSet<PointofSales> PointofSales { get; set; }
    }
}