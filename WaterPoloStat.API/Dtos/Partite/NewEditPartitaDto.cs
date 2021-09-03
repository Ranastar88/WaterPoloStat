using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WaterPoloStat.API.Dtos.Partite
{
    public class NewEditPartitaDto
    {
        public int? Id { get; set; }
        [Required]
        public DateTime Data { get; set; }
        [Required]
        public string Campionato { get; set; }
        [Required]
        public string Citta { get; set; }
        public string Luogo { get; set; }
        public NewEditSquadraDto SquadraCasa { get; set; }
        public NewEditSquadraDto SquadraOspiti { get; set; }
    }
}
