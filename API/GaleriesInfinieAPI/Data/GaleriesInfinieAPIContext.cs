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

            Galerie G1 = new Galerie { Id = 1, Name = "Photos de Vacances",  Private = true, FileName = "8F8BC7A2-01A4-40CD-80FB-34B401A038A1.jfif", MimeType = "image/jfif" };

            Galerie G2 = new Galerie { Id = 2, Name = "Photos de SCP-096", Private = false, FileName = "B5669E0D-8906-49E5-9963-EFB5913EE6AC.png" , MimeType = "image/png"};

            builder.Entity<Galerie>().HasData(G1);
            byte[] file = System.IO.File.ReadAllBytes(Directory.GetCurrentDirectory() + "/images/original/" + G1.FileName);
            Image image = Image.Load(file);
            image.Mutate(i => i.Resize(new ResizeOptions()
            {
                Mode = ResizeMode.Min
             ,
                Size = new Size() { Width = 320 }
            }));
            image.Save(Directory.GetCurrentDirectory() + "/images/miniature/" + G1.FileName);
            builder.Entity<Galerie>().HasData(G2);
            byte[] file2 = System.IO.File.ReadAllBytes(Directory.GetCurrentDirectory() + "/images/original/" + G2.FileName);
            Image image2 = Image.Load(file2);
            image2.Mutate(i => i.Resize(new ResizeOptions()
            {
                Mode = ResizeMode.Min
             ,
                Size = new Size() { Width = 320 }
            }));
            image2.Save(Directory.GetCurrentDirectory() + "/images/miniature/" + G2.FileName);
            builder.Entity<Galerie>()
                .HasMany(g => g.Propriétaires)
                .WithMany(u => u.Galeries)
                .UsingEntity(e =>
                {
                    e.HasData(new { PropriétairesId = U1.Id, GaleriesId = G1.Id });
                    e.HasData(new { PropriétairesId = U2.Id, GaleriesId = G2.Id });


                });

            Photo P1 = new Photo() { FileName = "E88FF195-3C28-4763-AB34-473E34C9BBB5.jpg", GalerieId = G1.Id, MimeType = "image/jpg", PhotoId = 1 };
            builder.Entity<Photo>().HasData(P1);
            byte[] file3 = System.IO.File.ReadAllBytes(Directory.GetCurrentDirectory() + "/images/original/" + P1.FileName);
            Image image3 = Image.Load(file3);
            image3.Mutate(i => i.Resize(new ResizeOptions()
            {
                Mode = ResizeMode.Min
             ,
                Size = new Size() { Width = 320 }
            }));
            image3.Save(Directory.GetCurrentDirectory() + "/images/miniature/" + P1.FileName);



            Photo P2 = new Photo() { FileName = "41EA5083-34D0-45E4-97E1-87D4866CF585.jpg", GalerieId = G2.Id, MimeType = "image/jpg", PhotoId = 2 };
            builder.Entity<Photo>().HasData(P2);
            byte[] file4 = System.IO.File.ReadAllBytes(Directory.GetCurrentDirectory() + "/images/original/" + P2.FileName);
            Image image4 = Image.Load(file4);
            image4.Mutate(i => i.Resize(new ResizeOptions()
            {
                Mode = ResizeMode.Min
             ,
                Size = new Size() { Width = 320 }
            }));
            image4.Save(Directory.GetCurrentDirectory() + "/images/miniature/" + P2.FileName);


            builder.Entity<Galerie>().HasMany(g => g.Photos)
                .WithOne(p => p.Galerie);
        }

    


    public DbSet<GaleriesInfinieAPI.Models.Galerie> Galerie { get; set; } = default!;
        public DbSet<Photo> photo { get; set; } = default!;
    }
}
