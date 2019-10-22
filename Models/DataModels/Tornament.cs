using DAIF2020.Models.SettingModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DAIF2020.Models.DataModels
{
    public class Tornament
    {
        public int Id { get; set; }
        [Display(Name = "Tournament")]
        public string TournamentName { get; set; }
        
        //Tournament DateTime Prop !
        [Display(Name = "Date&Time")]
        public DateTime TournamentDateTime { get; set; }

        // Tournament settings props !   

        [Display(Name = "Type")]
        public int? TournamentTypeId { get; set; }
        [Display(Name = "Type")]
        [ForeignKey("TournamentTypeId")]
        public TournamentType TournamentType { get; set; }

        //Tournament Games !
        // #1
        [Display(Name = "#1")]
        public int? GameId { get; set; }
        [Display(Name = "#1")]
        [ForeignKey("GameId")]
        public Game Game1 { get; set; }
        // #2
        [Display(Name = "#2")]
        public int? GameId1 { get; set; }
        [Display(Name = "#2")]
        [ForeignKey("GameId1")]
        public Game Game2 { get; set; }
        // #3
        [Display(Name = "#3")]
        public int? GameId2 { get; set; }
        [Display(Name = "#3")]
        [ForeignKey("GameId2")]
        public Game Game3 { get; set; }
        // #4
        [Display(Name = "#4")]
        public int? GameId3 { get; set; }
        [Display(Name = "#4")]
        [ForeignKey("GameId3")]
        public Game Game4 { get; set; }
        // #5
        [Display(Name = "#5")]
        public int? GameId4 { get; set; }
        [Display(Name = "#5")]
        [ForeignKey("GameId4")]
        public Game Game5 { get; set; }

        // #6
        [Display(Name = "#6")]
        public int? GameId5 { get; set; }
        [Display(Name = "#6")]
        [ForeignKey("GameId5")]
        public Game Game6 { get; set; }
        // #7
        [Display(Name = "#7")]
        public int? GameId6 { get; set; }
        [Display(Name = "#7")]
        [ForeignKey("GameId6")]
        public Game Game7 { get; set; }
        // #8
        [Display(Name = "#8")]
        public int? GameId7 { get; set; }
        [Display(Name = "#8")]
        [ForeignKey("GameId7")]
        public Game Game8 { get; set; }
        // #9
        [Display(Name = "#9")]
        public int? GameId8 { get; set; }
        [Display(Name = "#9")]
        [ForeignKey("GameId8")]
        public Game Game9 { get; set; }

        // #10
        [Display(Name = "#10")]
        public int? GameId9 { get; set; }
        [Display(Name = "#10")]
        [ForeignKey("GameId9")]
        public Game Game10 { get; set; }
        // #11
        [Display(Name = "#11")]
        public int? GameId10 { get; set; }
        [Display(Name = "#11")]
        [ForeignKey("GameId10")]
        public Game Game11 { get; set; }
        // #12
        [Display(Name = "#12")]
        public int? GameId11 { get; set; }
        [Display(Name = "#12")]
        [ForeignKey("GameId11")]
        public Game Game12 { get; set; }
        // #13
        [Display(Name = "#13")]
        public int? GameId12 { get; set; }
        [Display(Name = "#13")]
        [ForeignKey("GameId12")]
        public Game Game13 { get; set; }
        // #14
        [Display(Name = "#14")]
        public int? GameId13 { get; set; }
        [Display(Name = "#14")]
        [ForeignKey("GameId13")]
        public Game Game14 { get; set; }
        // #15
        [Display(Name = "#15")]
        public int? GameId14 { get; set; }
        [Display(Name = "#15")]
        [ForeignKey("GameId14")]
        public Game Game15 { get; set; }

    }
}
