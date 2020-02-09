using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WaterPoloStat.Domain
{
    public class Ruolo
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public virtual ICollection<Lineup> Lineups { get; set; }
        public Ruolo()
        {
            Lineups = new List<Lineup>();
        }
    }
}
