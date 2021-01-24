using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WaterPoloStat.Domain.Enum;

namespace WaterPoloStat.Domain
{
    [Table("Partite", Schema = "wps")]
    public class Partita : BaseInfo
    {
        public int Id { get; set; }
        public string Luogo { get; set; }
        public string Campionato { get; set; }
        public string Citta { get; set; }
        public DateTime? Data { get; set; }
        public string Orario { get; set; }
        [Required]
        public int IdSquadraCasa { get; set; }
        [Required]
        public int IdSquadraOspiti { get; set; }
        public int GoalCasa { get; set; }
        public int GoalOspiti { get; set; }
        public bool Iniziata { get; set; }
        public bool Terminata { get; set; }
        public bool CondividiLive { get; set; }
        public int Minuti { get; set; }
        public int Secondi { get; set; }
        public TempoDiGioco Tempo { get; set; }
        public virtual ICollection<Evento> Eventi { get; set; }
        public virtual ICollection<Lineup> Lineups { get; set; }
        public Partita()
        {
            Eventi = new List<Evento>();
            Lineups = new List<Lineup>();
        }
    }
}
