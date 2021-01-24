using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WaterPoloStat.Domain
{
    [Table("Giocatori", Schema = "wps")]
    public class Giocatore : BaseInfo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [Required]
        public string Cognome { get; set; }
        public DateTime? DataDiNascita { get; set; }
        public string Nazionalita { get; set; }
        public virtual ICollection<Lineup> Lineups { get; set; }
        public Giocatore()
        {
            Lineups = new List<Lineup>();
        }
    }
}

