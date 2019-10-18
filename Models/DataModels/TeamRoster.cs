using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DAIF2020.Models.DataModels
{
    public class TeamRoster
    {
        public int Id { get; set; }
        [Display(Name ="Team Roster")]
        public string TeamRosterName { get; set; }

        [Display(Name = "GM")]
        public int? PersonId { get; set; }
        [Display(Name = "GM")]
        [ForeignKey("PersonId")]
        public Person GM { get; set; }

        [Display(Name = "Head Coach")]
        public int? PersonId1 { get; set; }
        [Display(Name = "Head Coach")]
        [ForeignKey("PersonId1")]
        public Person HeadCoach { get; set; }

        [Display(Name = "Ass.Coach")]
        public int? PersonId2 { get; set; }
        [Display(Name = "Ass.Coach")]
        [ForeignKey("PersonId2")]
        public Person AssCoach { get; set; }

    }
}
