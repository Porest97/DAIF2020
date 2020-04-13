using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DAIF2020.SRHLStats2020.Models.DataModels
{
    public class Lag
    {
        public int Id { get; set; }

        [Display(Name="Team")]
        public string LagNamn { get; set; }
    }
}
