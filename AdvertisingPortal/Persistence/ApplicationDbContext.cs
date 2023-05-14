using AdvertisingPortal.Core.Models.Domains;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using System.Collections.ObjectModel;

namespace AdvertisingPortal.Persistence
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
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
        }


        DbSet<Advertisement> Advertisements => Set<Advertisement>();
        DbSet<Category> Categories => Set<Category>();
        DbSet<Picture> Pictures => Set<Picture>();
        DbSet<Message> Messages => Set<Message>();
    }
}