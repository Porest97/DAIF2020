using System.ComponentModel.DataAnnotations;

namespace DAIF2020.SRHLStats2020.Models.DataModels
{
    public class MatchType
    {
        public int Id { get; set; }

        [Display(Name = "Type")]
        public string MatchTypeName { get; set; }
    }
}