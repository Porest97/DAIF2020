using DAIF2020.Models.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DAIF2020.SportsLogs.Models.DataModels
{
    public class SportsLog
    {
        public int Id { get; set; }

        public int? PersonId { get; set; }
        [Display(Name = "Person")]
        [ForeignKey("PersonId")]
        public Person Person { get; set; }

        public int? SportId { get; set; }
        [Display(Name = "Sport")]
        [ForeignKey("SportId")]
        public Sport Sport { get; set; }

        [Display(Name = "Started")]
        public DateTime? DateTimeStart { get; set; }

        [Display(Name = "Ended")]
        public DateTime? DateTimeEnd { get; set; }

        [Display(Name ="Time in decimals ")]
        public decimal TimeSpent { get; set; }
    }
}
