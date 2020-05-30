using DAIF2020.SportsLogs.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAIF2020.SportsLogs.Models.ViewModels
{
    public class SPLViewModel
    {
        public List<SportsLog> SportLogs { get; internal set; }

        public List<Sport> Sports { get; set; }
    }
}
