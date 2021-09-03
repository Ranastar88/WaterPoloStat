using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WaterPoloStat.Domain
{
    public class WaterPoloStatDomain : IdentityDbContext<AspNetUser, IdentityRole, string>
    {
        private string _licenzaId;
        private string _userId;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WaterPoloStatDomain(DbContextOptions<WaterPoloStatDomain> options)
        : base(options)
        { }
        public WaterPoloStatDomain(DbContextOptions<WaterPoloStatDomain> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
            _licenzaId = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == "LicenzaId")?.Value;
            _userId = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == "nameid")?.Value;

        }

        public DbSet<AspNetUser> AspNetUsers { get; set; }
        public DbSet<Partita> Partite { get; set; }
        public DbSet<Ruolo> Ruoli { get; set; }
        public DbSet<Giocatore> Giocatori { get; set; }
        public DbSet<Evento> Eventi { get; set; }
        public DbSet<Lineup> Lineups { get; set; }
        public DbSet<Squadra> Squadre { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("imp");//schema default

            modelBuilder.Entity<Partita>().HasQueryFilter(x => !x.Cancellato && x.LicenzaId == _licenzaId);
            modelBuilder.Entity<Squadra>().HasQueryFilter(x => !x.Cancellato && x.LicenzaId == _licenzaId);
            modelBuilder.Entity<Lineup>().HasQueryFilter(x => !x.Cancellato && x.LicenzaId == _licenzaId);
            modelBuilder.Entity<Giocatore>().HasQueryFilter(x => !x.Cancellato && x.LicenzaId == _licenzaId);
            modelBuilder.Entity<Evento>().HasQueryFilter(x => !x.Cancellato && x.LicenzaId == _licenzaId);

            modelBuilder.Entity<Evento>()
                .HasOne(e => e.Partita)
                .WithMany(x => x.Eventi)
                .HasForeignKey(x => x.PartitaId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Partita>()
                .HasOne(e => e.SquadraCasa)
                .WithMany(x => x.PartiteCasa)
                .HasForeignKey(x => x.SquadraCasaId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Partita>()
                .HasOne(e => e.SquadraOspiti)
                .WithMany(x => x.PartiteOspiti)
                .HasForeignKey(x => x.SquadraOspitiId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeTracker.DetectChanges();

            //Insert
            foreach (var item in ChangeTracker.Entries().Where(
                e =>
                    e.State == EntityState.Added && e.Metadata.GetProperties().Any(p => p.Name == "LicenzaId") && e.Metadata.GetProperties().Any(p => p.Name == "CreatoDa")))
            {
                //item.CurrentValues["Id"] = Guid.NewGuid();

                if (_licenzaId == null) return Task.FromException<int>(new Exception("Errore: licenza id obbligatorio"));
                item.CurrentValues["LicenzaId"] = _licenzaId;

                if (_userId == null) return Task.FromException<int>(new Exception("Errore: user id obbligatorio"));
                item.CurrentValues["CreatoDa"] = _userId;
                item.CurrentValues["DataCreazione"] = DateTime.UtcNow;
            }

            //Update
            foreach (var item in ChangeTracker.Entries().Where(
                e =>
                    e.State == EntityState.Modified && e.Metadata.GetProperties().Any(p => p.Name == "ModificatoDa")))
            {
                if (_userId == null) return Task.FromException<int>(new Exception("Errore: user id obbligatorio"));
                item.CurrentValues["ModificatoDa"] = _userId;
                item.CurrentValues["DataUltimaModifica"] = DateTime.UtcNow;
            }

            //Delete
            foreach (var item in ChangeTracker.Entries().Where(
                e =>
                    e.State == EntityState.Deleted && e.Metadata.GetProperties().Any(p => p.Name == "Cancellato")))
            {
                item.State = EntityState.Modified;
                if (_userId == null) return Task.FromException<int>(new Exception("Errore: user id obbligatorio"));
                item.CurrentValues["CancellatoDa"] = _userId;
                item.CurrentValues["Cancellato"] = true;
                item.CurrentValues["DataCancellazione"] = DateTime.UtcNow;
            }

            return base.SaveChangesAsync();
        }
    }
}
