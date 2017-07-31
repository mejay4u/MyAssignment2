using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyAssignment2.Models.Entries
{
    public class SalesItemInfo
    {
        public Guid ItemId { get; set; }
        public decimal ItemRate { get; set; }
        public decimal ItemAmount { get; set; }
        public int Qty { get; set; }
    }
}