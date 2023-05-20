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
            throw new NotImplementedException();
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

        public void UpdateAdvertisement(Advertisement advertisement)
        {
            throw new NotImplementedException();
        }
    }
}
