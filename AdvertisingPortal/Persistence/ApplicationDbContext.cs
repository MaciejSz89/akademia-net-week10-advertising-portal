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



        DbSet<Advertisement> Advertisements { get; set;}
        DbSet<Category> Categories { get; set;}
        DbSet<Picture> Pictures { get; set;}
    }
}