using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DAIF2020.CleverServiceIX.DataModels
{
    public class RefFees
    {
        public int Id { get; set; }
        [Display(Name = "Kategori")]
        public string Category { get; set; }
        [Display(Name ="Matchledare")]
        [DataType(DataType.Currency)]
        public double UDZ { get; set; }

        [Display(Name = "HD")]
        [DataType(DataType.Currency)]
        public double HD { get; set; }

        [Display(Name = "LD")]
        [DataType(DataType.Currency)]
        public double LD { get; set; }
    }
}
