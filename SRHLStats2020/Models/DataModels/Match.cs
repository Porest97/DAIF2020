using DAIF2020.Models.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DAIF2020.SRHLStats2020.Models.DataModels
{
    public class Match
    {
        public int Id { get; set; }

        //Match DateTime Prop !
        [Display(Name = "Date&Time")]
        [DisplayFormat(DataFormatString = "{0:ddd yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime MatchDateTime { get; set; }

        // Game Identification Prop!
        [Display(Name = "Match #")]
        public string MatchNumber { get; set; }

        // Game TSM Idenfication Prop !
        [Display(Name = "TSM #")]
        public string TSMNumber { get; set; }

        // Game settings props !
        [Display(Name = "Category")]
        public int? MatchCategoryId { get; set; }
        [Display(Name = "Category")]
        [ForeignKey("MatchCategoryId")]
        public MatchCategory MatchCategory { get; set; }

        [Display(Name = "Status")]
        public int? MatchStatusId { get; set; }
        [Display(Name = "Status")]
        [ForeignKey("MatchStatusId")]
        public MatchStatus MatchStatus { get; set; }

        [Display(Name = "Match Type")]
        public int? MatchTypeId { get; set; }
        [Display(Name = "Match Type")]
        [ForeignKey("MatchTypeId")]
        public MatchType MatchType { get; set; }

        [Display(Name = "Series")]
        public int? SeriesId { get; set; }
        [Display(Name = "Series")]
        [ForeignKey("SeriesId")]
        public Series Series { get; set; }

        // Game location prop !
        [Display(Name = "Arena")]
        public int? ArenaId { get; set; }
        [Display(Name = "Arena")]
        [ForeignKey("ArenaId")]
        public Arena Arena { get; set; }

        // Game Teams Props !
        [Display(Name = "Home")]
        public int? LagId { get; set; }
        [Display(Name = "Home")]
        [ForeignKey("LagId")]
        public Lag HomeTeam { get; set; }

        [Display(Name = "Away")]
        public int? LagId1 { get; set; }
        [Display(Name = "Away")]
        [ForeignKey("LagId1")]
        public Lag AwayTeam { get; set; }

        // Game Result Props !
        [Display(Name = "Score Home Team")]
        public int? HomeTeamScore { get; set; }

        [Display(Name = "Score Away Team")]
        public int? AwayTeamScore { get; set; }

        [Display(Name = "Score")]
        public string Result { get { return string.Format("{0} {1} {2}", HomeTeamScore, "-", AwayTeamScore); } }

        // Game Ref props !
        [Display(Name = "HD")]
        public int? PersonId { get; set; }
        [Display(Name = "HD")]
        [ForeignKey("PersonId")]
        public Person HD1 { get; set; }

        [Display(Name = "HD")]
        public int? PersonId1 { get; set; }
        [Display(Name = "HD")]
        [ForeignKey("PersonId1")]
        public Person HD2 { get; set; }

        [Display(Name = "LD")]
        public int? PersonId2 { get; set; }
        [Display(Name = "LD")]
        [ForeignKey("PersonId2")]
        public Person LD1 { get; set; }

        [Display(Name = "LD")]
        public int? PersonId3 { get; set; }
        [Display(Name = "LD")]
        [ForeignKey("PersonId3")]
        public Person LD2 { get; set; }
    }
}
