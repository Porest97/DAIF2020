using System.ComponentModel.DataAnnotations;

namespace DAIF2020.CleverServiceIX.DataModels
{
    public class PaymentStatus
    {
        public int Id { get; set; }

        [Display(Name ="Payment status")]
        public string PaymentStatusName { get; set; }
    }
}