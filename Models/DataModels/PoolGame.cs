using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DAIF2020.Models.DataModels
{
    public class PoolGame
    {
        public int Id { get; set; }

        //PoolGame DateTime Prop !
        [Display(Name = "Date&Time")]
        public DateTime PoolGameDateTime { get; set; }

        //PoolGame Name Prop !
        [Display(Name = "Pool Game")]
        public string PoolGameName { get; set; }

        //PoolGame location prop !
        [Display(Name = "Arena")]
        public int? ArenaId { get; set; }
        [Display(Name = "Arena")]
        [ForeignKey("ArenaId")]
        public Arena Arena { get; set; }

        // PoolGame Hosting Team Prop !
        [Display(Name = "Hosting Team")]
        public int? ClubId { get; set; }
        [Display(Name = "Hosting Team")]
        [ForeignKey("ClubId")]
        public Club HostingTeam { get; set; }

        // ZoneGames props !

        //ZoneGame 1
        [Display(Name = "Zone Game 1")]
        public int? ZoneGameId { get; set; }
        [Display(Name = "Zone Game 1")]
        [ForeignKey("ZoneGameId")]
        public ZoneGame ZoneGame1 { get; set; }


        //ZoneGame 2
        [Display(Name = "Zone Game 2")]
        public int? ZoneGameId1 { get; set; }
        [Display(Name = "Zone Game 2")]
        [ForeignKey("ZoneGameId1")]
        public ZoneGame ZoneGame2 { get; set; }

        //ZoneGame 3
        [Display(Name = "Zone Game 3")]
        public int? ZoneGameId2 { get; set; }
        [Display(Name = "Zone Game 3")]
        [ForeignKey("ZoneGameId2")]
        public ZoneGame ZoneGame3 { get; set; }

    }
}
