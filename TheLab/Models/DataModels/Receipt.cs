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
    public class Receipt
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


        // Receipt Game Prop !
        [Display(Name = "Game")]
        public int? GameId { get; set; }
        [Display(Name = "Game")]
        [ForeignKey("GameId")]
        public Game Game { get; set; }

        // Fee calculations !
        // HD1
        [Display(Name = "FEE")]
        [DataType(DataType.Currency)]
        public int HD1Fee { get; set; } = 0;
        [Display(Name = "Travel")]
        [DataType(DataType.Currency)]
        public int HD1TravelKost { get; set; } = 0;
        [Display(Name = "Alowance")]
        [DataType(DataType.Currency)]
        public int HD1Alowens { get; set; } = 0;
        [Display(Name = "Lategame")]
        [DataType(DataType.Currency)]
        public int HD1LateGameKost { get; set; } = 0;
        [Display(Name = "Other")]
        [DataType(DataType.Currency)]
        public int HD1Other { get; set; } = 0;
        [Display(Name = "Total")]
        [DataType(DataType.Currency)]
        public int HD1TotalFee { get; set; } = 0;

        //HD2
        [Display(Name = "FEE")]
        [DataType(DataType.Currency)]
        public int HD2Fee { get; set; } = 0;
        [Display(Name = "Travel")]
        [DataType(DataType.Currency)]
        public int HD2TravelKost { get; set; } = 0;
        [Display(Name = "Alowance")]
        [DataType(DataType.Currency)]
        public int HD2Alowens { get; set; } = 0;
        [Display(Name = "Lategame")]
        [DataType(DataType.Currency)]
        public int HD2LateGameKost { get; set; } = 0;
        [Display(Name = "Other")]
        [DataType(DataType.Currency)]
        public int HD2Other { get; set; } = 0;
        [Display(Name = "Total")]
        [DataType(DataType.Currency)]
        public int HD2TotalFee { get; set; } = 0;

        // LD1
        [Display(Name = "FEE")]
        [DataType(DataType.Currency)]
        public int LD1Fee { get; set; } = 0;
        [Display(Name = "Travel")]
        [DataType(DataType.Currency)]
        public int LD1TravelKost { get; set; } = 0;
        [Display(Name = "Alowance")]
        [DataType(DataType.Currency)]
        public int LD1Alowens { get; set; } = 0;
        [Display(Name = "Lategame")]
        [DataType(DataType.Currency)]
        public int LD1LateGameKost { get; set; } = 0;
        [Display(Name = "Other")]
        [DataType(DataType.Currency)]
        public int LD1Other { get; set; } = 0;
        [Display(Name = "Total")]
        [DataType(DataType.Currency)]
        public int LD1TotalFee { get; set; } = 0;

        //LD2
        [Display(Name = "FEE")]
        [DataType(DataType.Currency)]
        public int LD2Fee { get; set; } = 0;
        [Display(Name = "Travel")]
        [DataType(DataType.Currency)]
        public int LD2TravelKost { get; set; } = 0;
        [Display(Name = "Alowance")]
        [DataType(DataType.Currency)]
        public int LD2Alowens { get; set; } = 0;
        [Display(Name = "Lategame")]
        [DataType(DataType.Currency)]
        public int LD2LateGameKost { get; set; } = 0;
        [Display(Name = "Other")]
        [DataType(DataType.Currency)]
        public int LD2Other { get; set; } = 0;
        [Display(Name = "Total")]
        [DataType(DataType.Currency)]
        public int LD2TotalFee { get; set; } = 0;
        // The Game total
        [Display(Name = "Game Total")]
        [DataType(DataType.Currency)]
        public int GameTotalKost { get; set; } = 0;

        //Accounting
        [Display(Name = "Amount Paid HD1")]
        [DataType(DataType.Currency)]
        public int AmountPaidHD1 { get; set; }


        [Display(Name = "Amount Paid HD2")]
        [DataType(DataType.Currency)]
        public int AmountPaidHD2 { get; set; }

        [Display(Name = "Amount Paid LD1")]
        [DataType(DataType.Currency)]
        public int AmountPaidLD1 { get; set; }

        [Display(Name = "Amount Paid LD2")]
        [DataType(DataType.Currency)]
        public int AmountPaidLD2 { get; set; }

        [Display(Name = "Total Amount Paid")]
        [DataType(DataType.Currency)]
        public int TotalAmountPaid { get; set; }

        [Display(Name = "Total Amount To Pay")]
        [DataType(DataType.Currency)]
        public int TotalAmountToPay { get; set; }
    }
}
