using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DAIF2020.Models.DataModels;
using DAIF2020.Models.SettingModels;
using DAIF2020.TheLab.Models.DataModels;
using DAIF2020.TSM.Models.DataModels;

namespace DAIF2020.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<DAIF2020.Models.DataModels.Arena> Arena { get; set; }
        public DbSet<DAIF2020.Models.SettingModels.ArenaStatus> ArenaStatus { get; set; }
        public DbSet<DAIF2020.Models.DataModels.Club> Club { get; set; }
        public DbSet<DAIF2020.Models.SettingModels.ClubStatus> ClubStatus { get; set; }
        public DbSet<DAIF2020.Models.DataModels.District> District { get; set; }
        public DbSet<DAIF2020.Models.DataModels.Person> Person { get; set; }
        public DbSet<DAIF2020.Models.SettingModels.PersonRole> PersonRole { get; set; }
        public DbSet<DAIF2020.Models.SettingModels.PersonStatus> PersonStatus { get; set; }
        public DbSet<DAIF2020.Models.SettingModels.PersonType> PersonType { get; set; }
        public DbSet<DAIF2020.Models.SettingModels.GameType> GameType { get; set; }
        public DbSet<DAIF2020.Models.SettingModels.GameStatus> GameStatus { get; set; }
        public DbSet<DAIF2020.Models.SettingModels.GameCategory> GameCategory { get; set; }
        public DbSet<DAIF2020.Models.SettingModels.ReceiptCategory> ReceiptCategory { get; set; }
        public DbSet<DAIF2020.Models.SettingModels.ReceiptStatus> ReceiptStatus { get; set; }
        public DbSet<DAIF2020.Models.SettingModels.ReceiptType> ReceiptType { get; set; }
        public DbSet<DAIF2020.Models.DataModels.Game> Game { get; set; }
        public DbSet<DAIF2020.Models.SettingModels.Zone> Zone { get; set; }
        public DbSet<DAIF2020.Models.DataModels.ZoneGame> ZoneGame { get; set; }
        public DbSet<DAIF2020.Models.DataModels.PoolGame> PoolGame { get; set; }
        public DbSet<DAIF2020.Models.SettingModels.SeriesStatus> SeriesStatus { get; set; }
        public DbSet<DAIF2020.Models.SettingModels.TeamStatus> TeamStatus { get; set; }
        public DbSet<DAIF2020.Models.DataModels.Series> Series { get; set; }
        public DbSet<DAIF2020.Models.DataModels.Team> Team { get; set; }
        public DbSet<DAIF2020.Models.DataModels.TeamRoster> TeamRoster { get; set; }
        public DbSet<DAIF2020.TheLab.Models.DataModels.Receipt> Receipt { get; set; }
        public DbSet<DAIF2020.TheLab.Models.DataModels.PoolGameReceipt> PoolGameReceipt { get; set; }
        public DbSet<DAIF2020.TheLab.Models.DataModels.ZoneGameReceipt> ZoneGameReceipt { get; set; }
        public DbSet<DAIF2020.Models.DataModels.Tornament> Tornament { get; set; }
        public DbSet<DAIF2020.Models.SettingModels.TournamentType> TournamentType { get; set; }
        public DbSet<DAIF2020.TheLab.Models.DataModels.WeeklyReceipt> WeeklyReciept { get; set; }
        public DbSet<DAIF2020.TSM.Models.DataModels.TSMGameStatus> TSMGameStatus { get; set; }
        public DbSet<DAIF2020.TSM.Models.DataModels.TSMGame> TSMGame { get; set; }
    }
}
