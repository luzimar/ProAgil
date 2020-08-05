using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain.Models;

namespace ProAgil.Infra.Data.Context
{
    public class ProAgilContext : DbContext
    {
        public ProAgilContext(DbContextOptions<ProAgilContext> options):base(options)
        { }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<PalestranteEvento> PalestrantesEventos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<RedeSocial> RedesSocials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<PalestranteEvento>()
                       .HasKey(PE => new { PE.EventoId, PE.PalestranteId });

            modelBuilder.Entity<Evento>().OwnsOne(p => p.QtdPessoas)
                                          .Property(p => p.Quantidade).HasColumnName("QtdPessoas");

            modelBuilder.Entity<Evento>().OwnsOne(p => p.Email)
                                          .Property(p => p.Address).HasColumnName("Email");

            modelBuilder.Entity<Palestrante>().OwnsOne(p => p.Email)
                                              .Property(p => p.Address).HasColumnName("Email");

            modelBuilder.Ignore<Notification>();

            modelBuilder.Entity<PalestranteEvento>().Ignore(c => c.Id);
        }
    }
}