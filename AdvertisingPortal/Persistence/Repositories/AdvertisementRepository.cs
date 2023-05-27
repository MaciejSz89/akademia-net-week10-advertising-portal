using AdvertisingPortal.Core;
using AdvertisingPortal.Core.Models.Domains;
using AdvertisingPortal.Core.Models.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AdvertisingPortal.Persistence.Repositories
{
    public class AdvertisementRepository : IAdvertisementRepository
    {
        private IApplicationDbContext _context;
        public AdvertisementRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public void AddAdvertisement(Advertisement advertisement)
        {
            _context.Advertisements.Add(advertisement);
        }

        public Advertisement GetAdvertisement(string userId, int advertisementId)
        {
            return _context.Advertisements
                           .Include(x => x.Pictures)
                           .Single(x => x.UserId == userId
                                     && x.Id == advertisementId);
        }

        public Advertisement GetAdvertisement(int id)
        {
            return _context.Advertisements
                           .Include(x => x.User)
                           .Include(x => x.Pictures)
                           .Single(x => x.Id == id);
        }

        public IEnumerable<Advertisement> GetAdvertisements()
        {
            return _context.Advertisements
                           .Include(x => x.User)
                           .Include(x => x.Pictures)
                           .ToList();
        }

        public IEnumerable<Advertisement> GetAdvertisements(string userId)
        {
            return _context.Advertisements
                           .Where(x => x.UserId == userId)
                           .Include(x => x.User)
                           .Include(x => x.Pictures)
                           .ToList();
        }

        public void UpdateAdvertisement(Advertisement advertisement)
        {
            var advertisementToUpdate = _context.Advertisements.Single(x => x.Id == advertisement.Id 
                                                                         && x.UserId == advertisement.UserId);
            advertisementToUpdate.CategoryId = advertisement.CategoryId;
            advertisementToUpdate.Title = advertisement.Title;
            advertisementToUpdate.Price = advertisement.Price;
            advertisementToUpdate.Description = advertisement.Description;
            advertisementToUpdate.Location = advertisement.Location;
            advertisementToUpdate.Pictures = advertisement.Pictures;


            _context.Advertisements.Update(advertisementToUpdate);
        }
    }
}
