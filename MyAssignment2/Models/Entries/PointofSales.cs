using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyAssignment2.Models.Entries
{
    public class PointofSales
    {
        public int SBId { get; set; }
        [Key]
        public Guid BillId { get; set; }
        public string BillDate { get; set; }
        public int InvoiceNo { get; set; }
        public int ServiceType { get; set; }
        public Guid RooomId { get; set; }
        public Guid TableId { get; set; }
        public Guid ItemId { get; set; }
        public string ItemCode  { get; set; }
        public decimal TaxAmount  { get; set; }
        public decimal TotoalAmount { get; set; }
        [NotMapped]
        public virtual List<SalesItemInfo> SalesItemInfo { get; set; }


        [NotMapped]
        public List<SelectListItem> ServiceTypeList { get; set; }
        [NotMapped]
        public List<SelectListItem> RoomList { get; set; }
        [NotMapped]
        public List<SelectListItem> TableList { get; set; }
        [NotMapped]
        public List<SelectListItem> ItemList { get; set; }




    }
}