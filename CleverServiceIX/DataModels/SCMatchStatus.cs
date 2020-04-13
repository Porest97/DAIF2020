using System.ComponentModel.DataAnnotations;

namespace DAIF2020.CleverServiceIX.DataModels
{
    public class SCMatchStatus
    {
        public int Id { get; set; }

        [Display(Name ="Match status")]
        public string CSMatchStatusName { get; set; }
    }
}