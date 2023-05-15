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
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Picture>()
                        .HasOne(p=>p.User)
                        .WithMany(u=>u.Pictures)
                        .HasForeignKey(p=>p.UserId)
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

            //var defaultCategoriesNames = _configuration.GetSection("DefaultCategories").Get<List<string>>();

            //var defaultCategories = new List<Category>();

            //int k = 1;

            //foreach (var categoryName in defaultCategoriesNames)
            //{
            //    defaultCategories.Add(new Category(categoryName) { Id = k++ });
            //}

            //modelBuilder.Entity<Category>().HasData(defaultCategories);


        }


        DbSet<Advertisement> Advertisements => Set<Advertisement>();
        DbSet<Category> Categories => Set<Category>();
        DbSet<Picture> Pictures => Set<Picture>();
        DbSet<Message> Messages => Set<Message>();
    }
}