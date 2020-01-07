using DAIF2020.Models.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DAIF2020.Planner.Models.DataModels
{
    public class Meeting
    {
        public int Id { get; set; }

        [Display(Name ="Name")]
        public string MeetingName { get; set; }
        
        [Display(Name = "Description")]
        public string MeetingDescription { get; set; }

        public int? LocationId { get; set; }
        [Display(Name = "Location")]
        [ForeignKey("LocationId")]
        public Location Location { get; set; }
        
        public int? PersonId { get; set; }
        [Display(Name = "Host")]
        [ForeignKey("PersonId")]
        public Person Person { get; set; }


    }
}
