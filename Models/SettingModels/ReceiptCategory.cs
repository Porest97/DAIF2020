using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DAIF2020.Models.SettingModels
{
    public class ReceiptCategory
    {
        public int Id { get; set; }

        [Display(Name = "Category")]
        public string ReceiptCategoryName { get; set; }
    }
}
