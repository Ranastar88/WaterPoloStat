using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WaterPoloStat.Domain
{
    [Table("Ruoli", Schema = "lkp")]
    public class Ruolo
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Il Nome è obbligatorio.")]
        [MaxLength(50, ErrorMessage = "Il Nome non può contenere più di 50 caratteri.")]
        public string Nome { get; set; }
    }
}
