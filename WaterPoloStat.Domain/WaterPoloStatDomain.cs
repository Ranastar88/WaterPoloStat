using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace WaterPoloStat.Domain
{
    public class WaterPoloStatDomain : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public DbSet<Partita> Partite { get; set; }
        public DbSet<Ruolo> Ruoli { get; set; }
        public DbSet<Giocatore> Giocatori { get; set; }
        public DbSet<Evento> Eventi { get; set; }
        public DbSet<Lineup> Lineups { get; set; }
        public DbSet<Squadra> Squadre { get; set; }
        public WaterPoloStatDomain(DbContextOptions<WaterPoloStatDomain> options)
        : base(options)
        { }
    }
}
