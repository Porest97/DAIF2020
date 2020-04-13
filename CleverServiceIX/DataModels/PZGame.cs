using DAIF2020.Models.DataModels;
using DAIF2020.Models.SettingModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DAIF2020.CleverServiceIX.DataModels
{
    public class PZGame
    {
        public int Id { get; set; }

        [Display(Name ="PZGame")]
        public string PZGameName { get; set; }

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

        //ZoneGames !

        [Display(Name = "ZG 1")]
        public int? ZoneGameId { get; set; }
        [Display(Name = "ZG 1")]
        [ForeignKey("ZoneGameId")]
        public ZoneGame ZoneGame1 { get; set; }

        [Display(Name = "ZG 2")]
        public int? ZoneGameId1 { get; set; }
        [Display(Name = "ZG 2")]
        [ForeignKey("ZoneGameId1")]
        public ZoneGame ZoneGame2 { get; set; }

        [Display(Name = "ZG 3")]
        public int? ZoneGameId2 { get; set; }
        [Display(Name = "ZG 3")]
        [ForeignKey("ZoneGameId2")]
        public ZoneGame ZoneGame3 { get; set; }

        [Display(Name = "ZG 4")]
        public int? ZoneGameId3 { get; set; }
        [Display(Name = "ZG 4")]
        [ForeignKey("ZoneGameId3")]
        public ZoneGame ZoneGame4 { get; set; }

        [Display(Name = "ZG 5")]
        public int? ZoneGameId4 { get; set; }
        [Display(Name = "ZG 5")]
        [ForeignKey("ZoneGameId4")]
        public ZoneGame ZoneGame5 { get; set; }

        [Display(Name = "ZG 6")]
        public int? ZoneGameId5 { get; set; }
        [Display(Name = "ZG 6")]
        [ForeignKey("ZoneGameId5")]
        public ZoneGame ZoneGame6 { get; set; }

        [Display(Name = "ZG 7")]
        public int? ZoneGameId6 { get; set; }
        [Display(Name = "ZG 7")]
        [ForeignKey("ZoneGameId6")]
        public ZoneGame ZoneGame7 { get; set; }

        [Display(Name = "ZG 8")]
        public int? ZoneGameId7 { get; set; }
        [Display(Name = "ZG 8")]
        [ForeignKey("ZoneGameId7")]
        public ZoneGame ZoneGame8 { get; set; }

        [Display(Name = "ZG 9")]
        public int? ZoneGameId8 { get; set; }
        [Display(Name = "ZG 9")]
        [ForeignKey("ZoneGameId8")]
        public ZoneGame ZoneGame9 { get; set; }

        [Display(Name = "ZG 10")]
        public int? ZoneGameId9 { get; set; }
        [Display(Name = "ZG 10")]
        [ForeignKey("ZoneGameId9")]
        public ZoneGame ZoneGame10 { get; set; }

        [Display(Name = "ZG 11")]
        public int? ZoneGameId10 { get; set; }
        [Display(Name = "ZG 11")]
        [ForeignKey("ZoneGameId10")]
        public ZoneGame ZoneGame11 { get; set; }

        [Display(Name = "ZG 12")]
        public int? ZoneGameId11 { get; set; }
        [Display(Name = "ZG 12")]
        [ForeignKey("ZoneGameId11")]
        public ZoneGame ZoneGame12 { get; set; }

        //Location & HomeTeam !
        [Display(Name = "Hosting Club")]
        public int? ClubId { get; set; }
        [Display(Name = "Hosting Club")]
        [ForeignKey("ClubId")]
        public Club HostingClub { get; set; }

        [Display(Name = "Arena")]
        public int? ArenaId { get; set; }
        [Display(Name = "Arena")]
        [ForeignKey("ArenaId")]
        public Arena Arena { get; set; }

    }
}
