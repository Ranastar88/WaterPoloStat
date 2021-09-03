using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WaterPoloStat.API.Dtos.Partite
{
    public class NewEditGiocatoreDto
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public DateTime Data { get; set; }
        [Required]
        public int RuoloId { get; set; }
        [Required]
        public int Numero { get; set; }
        public int? GiocatoreId { get; set; }
        public int? LineupId { get; set; }
    }
}
