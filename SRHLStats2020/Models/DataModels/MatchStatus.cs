using System.ComponentModel.DataAnnotations;

namespace DAIF2020.SRHLStats2020.Models.DataModels
{
    public class MatchStatus
    {
        public int Id { get; set; }

        [Display(Name = "Status")]
        public string MatchStatusName { get; set; }
    }
}