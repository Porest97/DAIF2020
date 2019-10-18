using DAIF2020.Models.SettingModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DAIF2020.Models.DataModels
{
    public class Team
    {
        public int Id { get; set; }

        [Display(Name = "Team")]
        public string TeamName { get; set; }

        [Display(Name = "Club")]
        public int? ClubId { get; set; }
        [Display(Name = "Club")]
        [ForeignKey("ClubId")]
        public Club Club { get; set; }

        [Display(Name = "District")]
        public int? DistrictId { get; set; }
        [Display(Name = "District")]
        [ForeignKey("DistrictId")]
        public District District { get; set; }

        [Display(Name = "Home Arena")]
        public int? ArenaId { get; set; }
        [Display(Name = "Home Arena")]
        [ForeignKey("ArenaId")]
        public Arena Arena { get; set; }
        //Team Series and Status !
        [Display(Name = "Series")]
        public int? SeriesId { get; set; }
        [Display(Name = "Series")]
        [ForeignKey("SeriesId")]
        public Series Series { get; set; }

        public int? TeamStatusId { get; set; }
        [Display(Name = "Status")]
        [ForeignKey("TeamStatusId")]
        public TeamStatus TeamStatus { get; set; }

        //Team Roster !

        public int? TeamRosterId { get; set; }
        [Display(Name = "Team Roster")]
        [ForeignKey("TeamRosterId")]
        public TeamRoster TeamRoster { get; set; }

    }
}
