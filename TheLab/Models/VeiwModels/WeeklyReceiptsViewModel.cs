using DAIF2020.Models.DataModels;
using DAIF2020.TheLab.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAIF2020.TheLab.Models.VeiwModels
{
    public class WeeklyReceiptsViewModel
    {
        //WeeklyReceipts !
        public List<WeeklyReceipt> WeeklyReceipts { get; internal set; }

        //Type of games added to the Weelky Receipt !
        public List<Game> Games { get; internal set; }
        public List<ZoneGame> ZoneGames { get; internal set; }
    }
}
