using System.ComponentModel.DataAnnotations;

namespace DAIF2020.SRHLStats2020.Models.DataModels
{
    public class MatchCategory
    {
        public int Id { get; set; }

        [Display(Name = "Category")]
        public string MatchCategoryName { get; set; }
    }
}