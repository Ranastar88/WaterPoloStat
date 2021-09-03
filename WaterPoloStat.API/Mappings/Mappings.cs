using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterPoloStat.API.Dtos.Partite;
using WaterPoloStat.Domain;

namespace WaterPoloStat.API.Mappings
{
    public partial class Mappings : Profile
    {
        public Mappings()
        {
            AddGlobalIgnore("LicenzaId");
            AddGlobalIgnore("CreatoDa");
            AddGlobalIgnore("ModificatoDa");
            AddGlobalIgnore("DataCreazione");
            AddGlobalIgnore("DataUltimaModifica");
            AddGlobalIgnore("CancellatoDa");
            AddGlobalIgnore("Cancellato");
            AddGlobalIgnore("DataCancellazione");
            AddGlobalIgnore("MigrationOldId");
            AddGlobalIgnore("MigrationInfo");

            CreateMap<Partita, ElencoPartitaDto>()
                .ForMember(dto => dto.SquadraCasa, obj => obj.MapFrom(c => c.SquadraCasa.Nome))
                .ForMember(dto => dto.SquadraOspiti, obj => obj.MapFrom(c => c.SquadraOspiti.Nome));

            CreateMap<Partita, NewEditPartitaDto>()
                .ForPath(dto => dto.SquadraCasa.Giocatori, obj => obj.MapFrom(c => c.Lineups.Where(x => x.SquadraId == c.SquadraCasaId)))
                .ForPath(dto => dto.SquadraOspiti.Giocatori, obj => obj.MapFrom(c => c.Lineups.Where(x => x.SquadraId == c.SquadraOspitiId)))
                .ForPath(dto => dto.SquadraOspiti.SquadraId, obj => obj.MapFrom(c => c.SquadraOspitiId))
                .ForPath(dto => dto.SquadraCasa.SquadraId, obj => obj.MapFrom(c => c.SquadraCasaId))
                .ForPath(dto => dto.SquadraCasa.Nome, obj => obj.MapFrom(c => c.SquadraCasa.Nome))
                .ForPath(dto => dto.SquadraOspiti.Nome, obj => obj.MapFrom(c => c.SquadraOspiti.Nome))
                ;
            CreateMap<Lineup, NewEditGiocatoreDto>()
                .ForMember(dto => dto.GiocatoreId, obj => obj.MapFrom(c => c.GiocatoreId))
                .ForMember(dto => dto.LineupId, obj => obj.MapFrom(c => c.Id))
                .ForMember(dto => dto.Nome, obj => obj.MapFrom(c => c.Giocatore.Nominativo))
                .ForMember(dto => dto.Data, obj => obj.MapFrom(c => c.Giocatore.DataDiNascita));
        }
    }
}
