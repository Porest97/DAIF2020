﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DAIF2020.Models.SettingModels
{
    public class PersonRole
    {
        public int Id { get; set; }

        [Display(Name = "Role")]
        public string PersonRoleName { get; set; }
    }
}
