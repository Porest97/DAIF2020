using DAIF2020.Models.DataModels;
using DAIF2020.TheLab.Models.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DAIF2020.TheLab.Models.VeiwModels
{
    public class ReceiptsViewModel
    {
        public List<Receipt> Receipts { get; internal set; }

        public List<Game> Games { get; internal set; }
                
    }
}
