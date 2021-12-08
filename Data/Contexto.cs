using System;
using System.Collections.Generic;
using System.Text;
using EtecFilmes.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EtecFilmes.Data
{
    public class Contexto : IdentityDbContext<Usuario>
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            #region Identity
            builder.Entity<Usuario>(entity =>
            {
                entity.ToTable(name: "Usuario");
            });
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Perfil");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable(name: "UsuarioPerfil");
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable(name: "UsuarioClaims");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable(name: "UsuaioLogin");
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable(name: "PerfilClaims");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable(name: "UsuarioTokens");
            });
            #endregion
        }
    }
}

