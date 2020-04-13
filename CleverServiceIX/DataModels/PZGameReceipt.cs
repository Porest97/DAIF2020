using DAIF2020.Models.SettingModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DAIF2020.CleverServiceIX.DataModels
{
    public class PZGameReceipt
    {
        public int Id { get; set; }

        [Display(Name = "PZ Game")]
        public int? PZGameId { get; set; }
        [Display(Name = "PZ Game")]
        [ForeignKey("PZGameId")]
        public PZGame PZGame { get; set; }

        // Receipt settings props !
        [Display(Name = "Category")]
        public int? ReceiptCategoryId { get; set; }
        [Display(Name = "Category")]
        [ForeignKey("ReceiptCategoryId")]
        public ReceiptCategory ReceiptCategory { get; set; }

        [Display(Name = "Status")]
        public int? ReceiptStatusId { get; set; }
        [Display(Name = "Status")]
        [ForeignKey("ReceiptStatusId")]
        public ReceiptStatus ReceiptStatus { get; set; }

        [Display(Name = "Receipt Type")]
        public int? ReceiptTypeId { get; set; }
        [Display(Name = "ReceiptType")]
        [ForeignKey("ReceiptTypeId")]
        public ReceiptType ReceiptType { get; set; }

        //FEE Accounting !

        public double UDZ1Fee { get; set; }

        public double UDZ2Fee { get; set; }

        public double UDZ3Fee { get; set; }

        public double UDZ4Fee { get; set; }


    }
}
