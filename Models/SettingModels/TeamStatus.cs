﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DAIF2020.Models.SettingModels
{
    public class TeamStatus
    {
        public int Id { get; set; }

        [Display(Name ="Status")]
        public string TeamStatusName { get; set; }
    }
}
