using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WaterPoloStat.API.Dtos.Partite;
using WaterPoloStat.Domain;
using WaterPoloStat.Services.Interfaces;

namespace WaterPoloStat.API.Controllers
{
    [Route("api/partite")]
    [ApiController]
    public class PartiteController : ControllerBase
    {
        private readonly IService<Squadra> _squadreService;
        private readonly IService<Giocatore> _giocatoriService;
        public readonly IPartitaService _partitaService;
        private readonly IMapper _mapper;
        public PartiteController(IService<Squadra> squadreService, IService<Giocatore> giocatoriService,
            IPartitaService partitaService, IMapper mapper)
        {
            _squadreService = squadreService;
            _giocatoriService = giocatoriService;
            _partitaService = partitaService;
            _mapper = mapper;
        }
        // GET: api/Partite
        [HttpGet]
        public async Task<List<ElencoPartitaDto>> Get(CancellationToken cancellationToken = default)
        {
            var result = await _partitaService.GetPartiteAsync(cancellationToken);
            return _mapper.Map<List<ElencoPartitaDto>>(result);
        }

        // GET: api/Partite/5
        [HttpGet("{id}", Name = "GetPartitaById")]
        public async Task<NewEditPartitaDto> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var partita = await _partitaService.GetPartitaByIdAsync(id, cancellationToken);
            var result = _mapper.Map<NewEditPartitaDto>(partita);
            return result;
        }

        // POST: api/Partite
        [HttpPost]
        public async Task<ActionResult<string>> PostAsync([FromBody] NewEditPartitaDto model, CancellationToken cancellationToken = default)
        {
            if (!model.SquadraCasa.SquadraId.HasValue)
            {
                model.SquadraCasa.SquadraId = await _squadreService.InsertAndCommitAsync(
                    new Squadra() { Nome = model.SquadraCasa.Nome }, cancellationToken);
            }
            if (!model.SquadraOspiti.SquadraId.HasValue)
            {
                model.SquadraOspiti.SquadraId = await _squadreService.InsertAndCommitAsync(
                    new Squadra() { Nome = model.SquadraOspiti.Nome }, cancellationToken);
            }
            var rosterCasa = new List<Lineup>();
            foreach (var item in model.SquadraCasa.Giocatori)
            {
                if (!item.GiocatoreId.HasValue)
                {
                    item.GiocatoreId = await _giocatoriService.InsertAndCommitAsync(
                        new Giocatore()
                        {
                            Nominativo = item.Nome,
                            DataDiNascita = item.Data
                        }, cancellationToken);
                }

                rosterCasa.Add(new Lineup()
                {
                    GiocatoreId = item.GiocatoreId.Value,
                    Numero = item.Numero,
                    RuoloId = item.RuoloId,
                    SquadraId = model.SquadraCasa.SquadraId.Value
                });
            }

            var rosterOspiti = new List<Lineup>();
            foreach (var item in model.SquadraOspiti.Giocatori)
            {
                if (!item.GiocatoreId.HasValue)
                {
                    item.GiocatoreId = await _giocatoriService.InsertAndCommitAsync(
                        new Giocatore()
                        {
                            Nominativo = item.Nome,
                            DataDiNascita = item.Data
                        }, cancellationToken);
                }

                rosterOspiti.Add(new Lineup()
                {
                    GiocatoreId = item.GiocatoreId.Value,
                    Numero = item.Numero,
                    RuoloId = item.RuoloId,
                    SquadraId = model.SquadraCasa.SquadraId.Value
                });
            }
            var id = await _partitaService.NuovaPartitaAsync(model.Luogo, model.Campionato, model.Citta, model.Data,
                model.SquadraCasa.SquadraId.Value, model.SquadraOspiti.SquadraId.Value,
                rosterCasa, rosterOspiti, cancellationToken);
            model.Id = id;
            return CreatedAtRoute("GetPartitaById", new { id = id }, model);
        }

        // PUT: api/Partite/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] NewEditPartitaDto model, CancellationToken cancellationToken = default)
        {

            if (!model.SquadraCasa.SquadraId.HasValue)
            {
                model.SquadraCasa.SquadraId = await _squadreService.InsertAndCommitAsync(
                    new Squadra() { Nome = model.SquadraCasa.Nome }, cancellationToken);
            }
            if (!model.SquadraOspiti.SquadraId.HasValue)
            {
                model.SquadraOspiti.SquadraId = await _squadreService.InsertAndCommitAsync(
                    new Squadra() { Nome = model.SquadraOspiti.Nome }, cancellationToken);
            }
            var rosterCasa = new List<Lineup>();
            foreach (var item in model.SquadraCasa.Giocatori)
            {
                if (!item.GiocatoreId.HasValue)
                {
                    item.GiocatoreId = await _giocatoriService.InsertAndCommitAsync(
                        new Giocatore()
                        {
                            Nominativo = item.Nome,
                            DataDiNascita = item.Data
                        }, cancellationToken);
                }

                rosterCasa.Add(new Lineup()
                {
                    GiocatoreId = item.GiocatoreId.Value,
                    Numero = item.Numero,
                    RuoloId = item.RuoloId,
                    SquadraId = model.SquadraCasa.SquadraId.Value
                });
            }

            var rosterOspiti = new List<Lineup>();
            foreach (var item in model.SquadraOspiti.Giocatori)
            {
                if (!item.GiocatoreId.HasValue)
                {
                    item.GiocatoreId = await _giocatoriService.InsertAndCommitAsync(
                        new Giocatore()
                        {
                            Nominativo = item.Nome,
                            DataDiNascita = item.Data
                        }, cancellationToken);
                }

                rosterOspiti.Add(new Lineup()
                {
                    GiocatoreId = item.GiocatoreId.Value,
                    Numero = item.Numero,
                    RuoloId = item.RuoloId,
                    SquadraId = model.SquadraCasa.SquadraId.Value
                });
            }
             await _partitaService.ModificaPartitaAsync(id,model.Luogo, model.Campionato, model.Citta, model.Data,
                model.SquadraCasa.SquadraId.Value, model.SquadraOspiti.SquadraId.Value,
                rosterCasa, rosterOspiti, cancellationToken);
            model.Id = id;
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
