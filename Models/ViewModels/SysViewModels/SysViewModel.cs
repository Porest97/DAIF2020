using DAIF2020.Models.DataModels;
using DAIF2020.Models.SettingModels;
using DAIF2020.TheLab.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAIF2020.Models.ViewModels.SysViewModels
{
    public class SysViewModel
    {
        //Associations, Locations, People and Games !
        public List<Arena> Arenas { get; internal set; }

        public List<Club> Clubs { get; internal set; }

        public List<District> Districts { get; internal set; }

        public List<Game> Games { get; internal set; }

        public List<Person> People { get; internal set; }

        public List<PoolGame> PoolGames { get; internal set; }

        public List<TeamRoster> TeamRosters { get; internal set; }

        public List<Team> Teams { get; internal set; }

        public List<Tornament> Tournaments { get; internal set; }

        public List<ZoneGame> ZoneGames { get; internal set; }

        //Settings !
        public List<ArenaStatus> ArenaStatuses { get; internal set; }

        public List<ClubStatus> ClubStatuses { get; internal set; }

        public List<PersonRole> PersonRoles { get; internal set; }

        public List<PersonStatus> PersonStatuses { get; internal set; }

        public List<PersonType> PersonTypes { get; internal set; }

        public List<GameCategory> GameCategories { get; internal set; }

        public List<GameStatus> GameStatuses { get; internal set; }

        public List<GameType> GameTypes { get; internal set; }

        public List<ReceiptCategory> ReceiptCategories { get; internal set; }

        public List<ReceiptStatus> ReceiptStatuses { get; internal set; }

        public List<ReceiptType> ReceiptTypes { get; internal set; }

        public List<Zone> Zones { get; internal set; }

        public List<TeamStatus> TeamStatuses { get; internal set; }

        public List<SeriesStatus> SeriesStatuses { get; internal set; }

        public List<TournamentType> TournamentTypes { get; internal set; }

        //Economics

        public List<PoolGameReceipt> PoolGameReceipts { get; internal set; }

        public List<Receipt> Receipts { get; internal set; }

        public List<ZoneGameReceipt> ZoneGameReceipts { get; internal set; }
    }
}
