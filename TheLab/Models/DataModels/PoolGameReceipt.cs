using DAIF2020.Models.DataModels;
using DAIF2020.Models.SettingModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DAIF2020.TheLab.Models.DataModels
{
    public class PoolGameReceipt
    {
        public int Id { get; set; }

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

        // Receipt PoolGame Prop !
        [Display(Name = "Pool Game")]
        public int? PoolGameId { get; set; }
        [Display(Name = "Pool Game")]
        [ForeignKey("PoolGameId")]
        public PoolGame PoolGame { get; set; }

        // Fee calculations !
        // UDZ1
        [Display(Name = "FEE")]
        [DataType(DataType.Currency)]
        public int UDZ1Fee { get; set; } = 0;
        [Display(Name = "Travel")]
        [DataType(DataType.Currency)]
        public int UDZ1TravelKost { get; set; } = 0;
        [Display(Name = "Alowance")]
        [DataType(DataType.Currency)]
        public int UDZ1Alowens { get; set; } = 0;
        [Display(Name = "Lategame")]
        [DataType(DataType.Currency)]
        public int DUZ1LateGameKost { get; set; } = 0;
        [Display(Name = "Other")]
        [DataType(DataType.Currency)]
        public int UDZ1Other { get; set; } = 0;
        [Display(Name = "Total")]
        [DataType(DataType.Currency)]
        public int UDZ1TotalFee { get; set; } = 0;

        // Fee calculations !
        // UDZ2
        [Display(Name = "FEE")]
        [DataType(DataType.Currency)]
        public int UDZ2Fee { get; set; } = 0;
        [Display(Name = "Travel")]
        [DataType(DataType.Currency)]
        public int UDZ2TravelKost { get; set; } = 0;
        [Display(Name = "Alowance")]
        [DataType(DataType.Currency)]
        public int UDZ2Alowens { get; set; } = 0;
        [Display(Name = "Lategame")]
        [DataType(DataType.Currency)]
        public int UDZ2LateGameKost { get; set; } = 0;
        [Display(Name = "Other")]
        [DataType(DataType.Currency)]
        public int UDZ2Other { get; set; } = 0;
        [Display(Name = "Total")]
        [DataType(DataType.Currency)]
        public int UDZ2TotalFee { get; set; } = 0;

        // The Game total
        [Display(Name = "Game Total")]
        [DataType(DataType.Currency)]
        public int PoolGameTotalKost { get; set; } = 0;

        //Accounting
        [Display(Name = "Amount Paid UDZ1")]
        [DataType(DataType.Currency)]
        public int AmountPaidUDZ1 { get; set; }


        [Display(Name = "Amount Paid UDZ2")]
        [DataType(DataType.Currency)]
        public int AmountPaidUDZ2 { get; set; }

        [Display(Name = "Total Amount Paid")]
        [DataType(DataType.Currency)]
        public int TotalAmountPaid { get; set; }

        [Display(Name = "Total Amount To Pay")]
        [DataType(DataType.Currency)]
        public int TotalAmountToPay { get; set; }


    }
}
