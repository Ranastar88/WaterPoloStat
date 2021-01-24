using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WaterPoloStat.Domain
{
    [Table("Lineups", Schema = "wps")]
    public class Lineup : BaseInfo
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        [Required]
        public int SquadraId { get; set; }
        [Required]
        public int GiocatoreId { get; set; }
        [Required] 
        public int RuoloId { get; set; }
        public virtual Squadra Squadra { get; set; }
        public virtual Giocatore Giocatore { get; set; }
        public virtual Ruolo Ruolo { get; set; }
    }
}
