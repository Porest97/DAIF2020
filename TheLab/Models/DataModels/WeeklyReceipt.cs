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
    public class WeeklyReceipt
    {
        public int Id { get; set; }

        //Status
        [Display(Name = "Status")]
        public int? ReceiptStatusId { get; set; }
        [Display(Name = "Status")]
        [ForeignKey("ReceiptStatusId")]
        public ReceiptStatus ReceiptStatus { get; set; }

        //Referee
        [Display(Name = "Referee")]
        public int? PersonId { get; set; }
        [Display(Name = "Referee")]
        [ForeignKey("PersonId")]
        public Person Referee { get; set; }

        //DateTime Period !
        [Display(Name ="Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
               
    }
}
