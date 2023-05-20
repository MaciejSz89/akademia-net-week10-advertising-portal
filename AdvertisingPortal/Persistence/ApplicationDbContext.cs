using AdvertisingPortal.Core;
using AdvertisingPortal.Core.Models.Domains;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.Configuration;

namespace AdvertisingPortal.Persistence
{
    public class ApplicationDbContext : IdentityDbContext, IApplicationDbContext
    {
        private readonly IConfiguration _configuration;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
            : base(options)
        {
            Advertisements = Set<Advertisement>();
            Messages = Set<Message>();
            Categories = Set<Category>();
            Pictures = Set<Picture>();
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Picture>()
                        .HasOne(p => p.User)
                        .WithMany(u => u.Pictures)
                        .HasForeignKey(p => p.UserId)
                        .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Message>()
                        .HasOne(c => c.Sender)
                        .WithMany(u => u.MessagesAsSender)
                        .HasForeignKey(c => c.SenderId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
                        .HasOne(c => c.Receiver)
                        .WithMany(u => u.MessagesAsReceiver)
                        .HasForeignKey(c => c.ReceiverId)
                        .OnDelete(DeleteBehavior.Restrict);




            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Elektronika" },
                new Category { Id = 2, Name = "Meble i wyposażenie wnętrz" },
                new Category { Id = 3, Name = "Motoryzacja" },
                new Category { Id = 4, Name = "Moda i odzież" },
                new Category { Id = 5, Name = "Sport i rekreacja" },
                new Category { Id = 6, Name = "Dom i ogród" },
                new Category { Id = 7, Name = "Dla dzieci" },
                new Category { Id = 8, Name = "Hobby i kolekcje" },
                new Category { Id = 9, Name = "Elektronika użytkowa" },
                new Category { Id = 10, Name = "Zwierzęta i akcesoria" });
        }

        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}