using DAIF2020.Models.SettingModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DAIF2020.Models.DataModels
{
    public class ZoneGame
    {
        public int Id { get; set; }

       
        // Game settings props !
        [Display(Name = "Category")]
        public int? GameCategoryId { get; set; }
        [Display(Name = "Category")]
        [ForeignKey("GameCategoryId")]
        public GameCategory GameCategory { get; set; }

        [Display(Name = "Status")]
        public int? GameStatusId { get; set; }
        [Display(Name = "Status")]
        [ForeignKey("GameStatusId")]
        public GameStatus GameStatus { get; set; }

        [Display(Name = "Game Type")]
        public int? GameTypeId { get; set; }
        [Display(Name = "GameType")]
        [ForeignKey("GameTypeId")]
        public GameType GameType { get; set; }


        // Zone 1 idetifyer !

        [Display(Name = "Zone 1")]
        public int? ZoneId { get; set; }
        [Display(Name = "Zone 1")]
        [ForeignKey("ZoneId")]
        public Zone Zone1 { get; set; }

        [Display(Name = "TSM #")]
        public string TSMNumberZone1 { get; set; }

        // Zone 1  Teams idetifyers !
        [Display(Name = "Home")]
        public int? ClubId { get; set; }
        [Display(Name = "Home")]
        [ForeignKey("ClubId")]
        public Club HomeTeam1 { get; set; }

        [Display(Name = "Away")]
        public int? ClubId1 { get; set; }
        [Display(Name = "Away")]
        [ForeignKey("ClubId1")]
        public Club AwayTeam1 { get; set; }

        //Zone 1 UDZ Identifyer!
        [Display(Name = "UDZ")]
        public int? PersonId { get; set; }
        [Display(Name = "UDZ")]
        [ForeignKey("PersonId")]
        public Person UDZ1 { get; set; }

        /// <summary>
        /// Boarder zone1 and zone2 !
        /// </summary>
        // Zone 2 idetifyer !
        [Display(Name = "Zone 2")]
        public int? ZoneId1 { get; set; }
        [Display(Name = "Zone 2")]
        [ForeignKey("ZoneId1")]
        public Zone Zone2 { get; set; }

        [Display(Name = "TSM #")]
        public string TSMNumberZone2 { get; set; }

        // Zone 2  Teams idetifyers !

        [Display(Name = "Home")]
        public int? ClubId2 { get; set; }
        [Display(Name = "Home")]
        [ForeignKey("ClubId2")]
        public Club HomeTeam2 { get; set; }

        [Display(Name = "Away")]
        public int? ClubId3 { get; set; }
        [Display(Name = "Away")]
        [ForeignKey("ClubId3")]
        public Club AwayTeam2 { get; set; }

        [Display(Name = "UDZ")]
        public int? PersonId1 { get; set; }
        [Display(Name = "UDZ")]
        [ForeignKey("PersonId1")]
        public Person UDZ2 { get; set; }

        // Sopervisor Identifyer !

        [Display(Name = "Supervisor")]
        public int? PersonId2 { get; set; }
        [Display(Name = "Supervisor")]
        [ForeignKey("PersonId2")]
        public Person Supervisor { get; set; }

        // ZoneGame DateTime, Arena, Name, Number
        
        [Display(Name = "Arena")]
        public int? ArenaId { get; set; }
        [Display(Name = "Arena")]
        [ForeignKey("ArenaId")]
        public Arena Arena { get; set; }
        
        public DateTime ZoneGameDateTime { get; set; }

        public DateTime ZoneGameName { get; set; }

        [Display(Name = "Zonegame #")]
        public string ZoneGameNumber { get { return string.Format("{0} {1} {2}", ZoneGameName, TSMNumberZone1, TSMNumberZone2); } }

    }
}
