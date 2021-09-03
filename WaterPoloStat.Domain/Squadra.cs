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
        public virtual ICollection<Partita> PartiteCasa { get; set; }
        public virtual ICollection<Partita> PartiteOspiti { get; set; }
        public Squadra()
        {
            Lineups = new List<Lineup>();
            PartiteCasa = new List<Partita>();
            PartiteOspiti = new List<Partita>();
        }
    }
}
