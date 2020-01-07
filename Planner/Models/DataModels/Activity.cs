using DAIF2020.Models.DataModels;
using DAIF2020.Models.SettingModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DAIF2020.Planner.Models.DataModels
{
    public class Activity
    {
        public int Id { get; set; }

        public string ActivityName { get; set; }

        public int? ActivityStatusId { get; set; }
        [Display(Name = "Status")]
        [ForeignKey("ActivityStatusId")]
        public ActivityStatus ActivityStatus { get; set; }

        [Display(Name = "Start DateTime Day")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd/ddd HH:mm}")]
        public DateTime FromDateTime { get; set; }

        [Display(Name = "End DateTime Day")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd/ddd HH:mm}")]
        public DateTime ToDateTime { get; set; }

        public int? GameId { get; set; }
        [Display(Name = "Game")]
        [ForeignKey("GameId")]
        public Game Game { get; set; }

        public int? PersonId { get; set; }
        [Display(Name = "Person")]
        [ForeignKey("PersonId")]
        public Person Person { get; set; }

        public int? MeetingId { get; set; }
        [Display(Name = "Meeting")]
        [ForeignKey("MeetingId")]
        public Meeting Meeting { get; set; }


    }
}
