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
        [Required(ErrorMessage = "Please provide bill date")]
        [Display(Name = "Bill Date")]
        public string BillDate { get; set; }

        [Required(ErrorMessage = "Please provide invoice no")]
        [Display(Name = "Invoice No")]
        public int InvoiceNo { get; set; }

        [Required(ErrorMessage = "Please provide service type")]
        [Display(Name = "Service Type")]
        public int ServiceType { get; set; }

        [Required(ErrorMessage = "Please provide room ")]
        [Display(Name = "Room")]
        public Guid RooomId { get; set; }

        [Required(ErrorMessage = "Please provide table ")]
        [Display(Name = "Table")]
        public Guid TableId { get; set; }


        public Guid ItemId { get; set; }
        public string ItemCode  { get; set; }
        public decimal TaxAmount  { get; set; }
        public decimal TotoalAmount { get; set; }
        [NotMapped]
        public  List<SalesItemInfo> SalesItemInfoA { get; set; }
        
        [NotMapped]
        public List<SelectListItem> ServiceTypeList { get; set; }
        [NotMapped]
        public List<SelectListItem> RoomList { get; set; }
        [NotMapped]
        public List<SelectListItem> TableList { get; set; }
        [NotMapped]
        public List<SelectListItem> ItemList { get; set; }
        [NotMapped]
        public int CurruntInvoiceNo { get; set; }

        [NotMapped]
        public decimal ItemRate { get; set; }
        [NotMapped]
        public decimal ItemAmount { get; set; }
        [NotMapped]
        public int Qty { get; set; }

    }
}