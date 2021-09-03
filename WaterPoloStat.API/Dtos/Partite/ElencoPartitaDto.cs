using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterPoloStat.API.Dtos.Partite
{
    public class ElencoPartitaDto
    {
        public int Id { get; set; }
        public string SquadraCasa { get; set; }
        public string SquadraOspiti { get; set; }
        public string Campionato { get; set; }
        public int GoalCasa { get; set; }
        public int GoalOspiti { get; set; }
        public bool Iniziata { get; set; }
        public bool Terminata { get; set; }
        public DateTime Data { get; set; }
    }
}