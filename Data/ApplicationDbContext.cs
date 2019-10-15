using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DAIF2020.Models.DataModels;
using DAIF2020.Models.SettingModels;

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
    }
}
