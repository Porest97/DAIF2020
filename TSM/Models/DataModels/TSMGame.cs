using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DAIF2020.TSM.Models.DataModels
{
    public class TSMGame
    {
        public int Id { get; set; }

        //TSMGame Data !
        [Display(Name ="Date&Time")]
        [DataType(DataType.DateTime)]
        public DateTime GameDateTime { get; set; }

        [Display(Name = "Weekday")]
        public string WeekDay { get; set; }

        [Display(Name = "TSM#")]
        public int? GameNumber { get; set; }

        [Display(Name = "Round")]
        public int? Round { get; set; }

        [Display(Name = "Home")]
        public string HomeTeam { get; set; }

        [Display(Name = "Away")]
        public string AwayTeam { get; set; }

        [Display(Name = "Arena")]
        public string Arena { get; set; }

        [Display(Name = "Series")]
        public string Series { get; set; }

        [Display(Name = "HD")]
        public string HD1 { get; set; }

        [Display(Name = "HD")]
        public string HD2 { get; set; }

        [Display(Name = "LD")]
        public string LD1 { get; set; }

        [Display(Name = "LD")]
        public string LD2 { get; set; }

        [Display(Name = "Supervisor")]
        public string Supervisor { get; set; }

        [Display(Name = "Changed")]
        public DateTime? DateChanged { get; set; }

        [Display(Name = "Changed By")]
        public string ChangedBy { get; set; }

        //Settings !
        [Display(Name = "Status")]
        public int? TSMGameStatusId { get; set; }
        [Display(Name = "Status")]
        [ForeignKey("TSMGameStatusId")]
        public TSMGameStatus TSMGameStatus { get; set; }

    }
}
