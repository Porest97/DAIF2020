using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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


        public int? GameId { get; set; }
        [Display(Name = "Game1")]
        [ForeignKey("GameId")]
        public Game Game1 { get; set; }

        public int? GameId1 { get; set; }
        [Display(Name = "Game2")]
        [ForeignKey("GameId1")]
        public Game Game2 { get; set; }

        public int? GameId2 { get; set; }
        [Display(Name = "Game3")]
        [ForeignKey("GameId2")]
        public Game Game3 { get; set; }



    }
}
