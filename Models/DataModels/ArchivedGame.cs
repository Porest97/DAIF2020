using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DAIF2020.Models.DataModels
{
    public class ArchivedGame
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public string GameNumber { get; set; }

        public string GameCetegory { get; set; }

        public string GameStatus { get; set; }

        public string GameType { get; set; }

        public string Arena { get; set; }

        public string HomeTeam { get; set; }

        public string AwayTeam { get; set; }

        public string Score { get; set; }

        public string HD1 { get; set; }

        public string HD2 { get; set; }

        public string LD1 { get; set; }

        public string LD2 { get; set; }

        public decimal ParticipatedTime { get; set; }

        [Display(Name = "Person")]
        public int? PersonId { get; set; }
        [Display(Name = "Person")]
        [ForeignKey("PersonId")]
        public Person Person { get; set; }
    }
}
