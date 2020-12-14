using Microsoft.EntityFrameworkCore;
using ProAgil.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProAgil.Repository
{
    public class ProAgilContext: DbContext
    {
        public ProAgilContext(DbContextOptions<ProAgilContext> options): base(options)
        {

        }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Palestrante> palestrantes { get; set; }
        public DbSet<PalestranteEvento> palestranteEventos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<RedeSocial> RedesSociais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PalestranteEvento>()
                .HasKey(PE => new { PE.EventoId, PE.PalestranteId });

        }
    }
}
