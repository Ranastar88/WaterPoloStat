using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WaterPoloStat.Domain.Enum;

namespace WaterPoloStat.Domain
{
    public class Evento
    {
        public int Id { get; set; }
        [Required]
        public int PartitaId { get; set; }
        public DateTime DataInserimento { get; set; }
        public int Minuti { get; set; }
        public int Secondi { get; set; }
        public TempoDiGioco Tempo { get; set; }
        public TipoEvento Tipo { get; set; }
        [Required]
        public int Lineup1Id { get; set; }
        public int? Lineup2Id { get; set; }
        public int? Lineup3Id { get; set; }
        public EsitoTiro? EsitoTiro { get; set; }
        public double? XPosizione { get; set; }
        public double? YPosizione { get; set; }
        public double? XTiro { get; set; }
        public double? YTiro { get; set; }
        public string Note { get; set; }

        public virtual Partita Partita { get; set; }
        public virtual Lineup Lineup1 { get; set; }
        public virtual Lineup Lineup2 { get; set; }
        public virtual Lineup Lineup3 { get; set; }
    }
}
