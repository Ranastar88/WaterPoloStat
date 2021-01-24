using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WaterPoloStat.Domain
{
    [Table("Squadre", Schema = "wps")]
    public class Squadra : BaseInfo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Lineup> Lineups { get; set; }
        public virtual ICollection<Partita> PartitaCasa { get; set; }
        public virtual ICollection<Partita> PartitaOspiti { get; set; }
        public Squadra()
        {
            Lineups = new List<Lineup>();
            PartitaCasa = new List<Partita>();
            PartitaOspiti = new List<Partita>();
        }
    }
}
