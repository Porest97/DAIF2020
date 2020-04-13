using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DAIF2020.Models.DataModels
{
    public class Hockey4LifeLog
    {
        public int Id { get; set; }

        [Display(Name ="Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string Events { get; set; }

        public int HockeyDay { get; set; }

        public int DayInLife { get; set; }

        public decimal Hours { get; set; }

        public int NumberOfGames { get; set; }

    }
}
