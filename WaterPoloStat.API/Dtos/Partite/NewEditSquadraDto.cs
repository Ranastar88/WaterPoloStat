using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WaterPoloStat.API.Dtos.Partite
{
    public class NewEditSquadraDto
    {
        [Required]
        public string Nome { get; set; }
        public int? SquadraId { get; set; }
        public List<NewEditGiocatoreDto> Giocatori { get; set; } = new List<NewEditGiocatoreDto>();
    }
}
