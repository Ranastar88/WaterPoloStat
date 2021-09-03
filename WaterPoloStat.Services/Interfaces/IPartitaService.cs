using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WaterPoloStat.Domain;

namespace WaterPoloStat.Services.Interfaces
{
    public interface IPartitaService
    {
        Task<int> NuovaPartitaAsync(string luogo, string campionato, string citta, DateTime data, int squadraCasaId, int squadraOpsitiId, List<Lineup> squadraCasa, List<Lineup> squadraOspiti, CancellationToken cancellationToken);
        Task ModificaPartitaAsync(int id, string luogo, string campionato, string citta, DateTime data, int squadraCasaId, int squadraOpsitiId, List<Lineup> squadraCasa, List<Lineup> squadraOspiti, CancellationToken cancellationToken);
        Task<List<Partita>> GetPartiteAsync(CancellationToken cancellationToken);
        Task<Partita> GetPartitaByIdAsync(int id, CancellationToken cancellationToken);
    }
}
