using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain;
using ProAgil.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProAgil.Repository
{
    public class ProAgilContext: IdentityDbContext<User,Role, int, IdentityUserClaim<int>, UserRoles, IdentityUserLogin<int>,
                                                    IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public ProAgilContext(DbContextOptions<ProAgilContext> options) : base(options)
        {

        }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Palestrante> palestrantes { get; set; }
        public DbSet<PalestranteEvento> palestranteEventos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<RedeSocial> RedesSociais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            

            modelBuilder.Entity<UserRoles>(UserRoles =>
            {
                UserRoles.HasKey(ur => new { ur.UserId, ur.RoleId });
                UserRoles.HasOne(ur => ur.Roles).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.RoleId).IsRequired();

                UserRoles.HasOne(ur => ur.User).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.RoleId).IsRequired();
            });

            modelBuilder.Entity<PalestranteEvento>()
                .HasKey(PE => new { PE.EventoId, PE.PalestranteId });

        }
    }
}
