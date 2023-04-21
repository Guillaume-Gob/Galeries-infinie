using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GaleriesInfinieAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace GaleriesInfinieAPI.Data
{
    public class GaleriesInfinieAPIContext : IdentityDbContext<User>
    {
        public GaleriesInfinieAPIContext (DbContextOptions<GaleriesInfinieAPIContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            PasswordHasher<User> hasher = new PasswordHasher<User>();

            User U1 = new User
            {
                Id = "2FB4F664-2E39-4C56-BC88-1DA9DFA859F8",
                UserName = "Maurice",
                Email = "Hotmail@Hotmail.ca",
                NormalizedEmail = "HOTMAIL@HOTMAIL.CA",
                NormalizedUserName = "MAURICE"
            };
            U1.PasswordHash = hasher.HashPassword(U1, "String!32");
            builder.Entity<User>().HasData(U1);

            User U2 = new User
            {
                Id = "00E5F11B-096E-43F0-B98B-EEE5F672B7B7",
                UserName = "Jean-Guy",
                Email = "Gmail@Hotmail.ca",
                NormalizedEmail = "GMAIL@HOTMAIL.CA",
                NormalizedUserName = "JEAN-GUY"
            };
            U2.PasswordHash = hasher.HashPassword(U2, "Varchar!32");
            builder.Entity<User>().HasData(U2);

            Galerie G1 = new Galerie { Id = 1, Name = "Photos de Vacances", ImageUrl = "aaaaa/aaaa.img", Private = true };
            Galerie G2 = new Galerie { Id = 2, Name = "Photos de SCP-096", ImageUrl = "aaaaa/aaaa.img", Private = false };

            builder.Entity<Galerie>().HasData(G1);
            builder.Entity<Galerie>().HasData(G2);
            builder.Entity<Galerie>()
                .HasMany(g => g.Propriétaires)
                .WithMany(u => u.Galeries)
                .UsingEntity(e =>
                {
                    e.HasData(new { PropriétairesId = U1.Id, GaleriesId = G1.Id });
                    e.HasData(new { PropriétairesId = U2.Id, GaleriesId = G2.Id });


                });

        }

        public DbSet<GaleriesInfinieAPI.Models.Galerie> Galerie { get; set; } = default!;
    }
}
