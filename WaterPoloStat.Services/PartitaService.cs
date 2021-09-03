using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WaterPoloStat.Domain;
using WaterPoloStat.Services.Interfaces;

namespace WaterPoloStat.Services
{
    public class PartitaService : BaseService<Partita>, IPartitaService
    {
        private readonly IService<Lineup> _lineupService;
        public PartitaService(IUnitOfWork uow, IService<Lineup> lineupService) : base(uow)
        {
            _lineupService = lineupService;
        }

        public async Task<List<Partita>> GetPartiteAsync(CancellationToken cancellationToken)
        {
            return await Query()
                .Include(x => x.SquadraOspiti)
                .Include(x => x.SquadraCasa)
                .OrderByDescending(x => x.Data).ToListAsync();
        }

        public async Task<Partita> GetPartitaByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await Query()
                .Include(x => x.SquadraOspiti)
                .Include(x => x.SquadraCasa)
                .Include(x => x.Lineups)
                .Include("Lineups.Giocatore")
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }


        public async Task<int> NuovaPartitaAsync(string luogo, string campionato, string citta, DateTime data, int squadraCasaId, int squadraOpsitiId, List<Lineup> squadraCasa, List<Lineup> squadraOspiti, CancellationToken cancellationToken)
        {
            var partita = new Partita()
            {
                Campionato = campionato,
                Luogo = luogo,
                Data = data,
                Citta = citta,
                SquadraCasaId = squadraCasaId,
                SquadraOspitiId = squadraOpsitiId,
                Terminata = false
            };
            await InsertAndCommitAsync(partita, cancellationToken);
            foreach (var item in squadraCasa)
            {
                item.PartitaId = partita.Id;
                await _lineupService.InsertAndCommitAsync(item, cancellationToken);
            }
            foreach (var item in squadraOspiti)
            {
                item.PartitaId = partita.Id;
                await _lineupService.InsertAndCommitAsync(item, cancellationToken);
            }
            return partita.Id;
        }

        public async Task ModificaPartitaAsync(int id, string luogo, string campionato, string citta, DateTime data, int squadraCasaId, int squadraOpsitiId, List<Lineup> squadraCasa, List<Lineup> squadraOspiti, CancellationToken cancellationToken)
        {
            var partita = await FindByIdAsync(id, cancellationToken);
            partita.Campionato = campionato;
            partita.Luogo = luogo;
            partita.Data = data;
            partita.Citta = citta;
            partita.SquadraCasaId = squadraCasaId;
            partita.SquadraOspitiId = squadraOpsitiId;
            partita.Terminata = false;

            await UpdateAndCommitAsync(partita, cancellationToken);
        }
    }
}
