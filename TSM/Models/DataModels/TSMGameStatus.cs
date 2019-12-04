using System.ComponentModel.DataAnnotations;

namespace DAIF2020.TSM.Models.DataModels
{
    public class TSMGameStatus
    {
        public int Id { get; set; }

        [Display(Name ="Status")]
        public string TSMGameStatusName { get; set; }
    }
}