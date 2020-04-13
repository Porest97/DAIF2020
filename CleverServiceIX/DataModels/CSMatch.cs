using DAIF2020.Models.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DAIF2020.CleverServiceIX.DataModels
{
    public class CSMatch
    {
        public int Id { get; set; }

        //CSMatch DateTime Prop !
        [Display(Name ="Match start")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]        
        public DateTime DateTimeMatch { get; set; }

        //CSMatch TSM Idenfication Prop !
        [Display(Name = "TSM #")]
        public string TSMNumber { get; set; }

       

        //SCMatch location prop !
        [Display(Name = "Arena")]
        public int? ArenaId { get; set; }
        [Display(Name = "Arena")]
        [ForeignKey("ArenaId")]
        public Arena Arena { get; set; }

        // Game Teams Props !
        [Display(Name = "Home")]
        public int? TeamId { get; set; }
        [Display(Name = "Home")]
        [ForeignKey("TeamId")]
        public Team HomeTeam { get; set; }

        [Display(Name = "Away")]
        public int? TeamId1 { get; set; }
        [Display(Name = "Away")]
        [ForeignKey("TeamId1")]
        public Team AwayTeam { get; set; }

        // Game Result Props !
        [Display(Name = "Score Home")]
        public int? HomeTeamScore { get; set; }

        [Display(Name = "Score Away")]
        public int? AwayTeamScore { get; set; }

        [Display(Name = "Score")]
        public string Result { get { return string.Format("{0} {1} {2}", HomeTeamScore, "-", AwayTeamScore); } }

        //CSMatch status props !
        [Display(Name = "Match status")]
        public int? CSMatchStatusId { get; set; }
        [Display(Name = "Match status")]
        [ForeignKey("CSMatchStatusId")]
        public SCMatchStatus SCMatchStatus { get; set; }

        //CSMatch Payment status props !
        [Display(Name = "Payment status")]
        public int? PaymentStatusId { get; set; }
        [Display(Name = "Payment status")]
        [ForeignKey("PaymentStatusId")]
        public PaymentStatus PaymentStatus { get; set; }

        // CSMatch Ref props !
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
