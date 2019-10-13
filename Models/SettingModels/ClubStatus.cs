﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DAIF2020.Models.SettingModels
{
    public class ClubStatus
    {
        public int Id { get; set; }

        [Display(Name ="Status")]
        public string ClubStatusName { get; set; }
    }
}
