using AdvertisingPortal.Core;
using AdvertisingPortal.Core.Models.Domains;
using AdvertisingPortal.Core.Models.Repositories;

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
            throw new NotImplementedException();
        }

        public Advertisement GetAdvertisement(string userId, int advertisementId)
        {
            throw new NotImplementedException();
        }

        public void UpdateAdvertisement(Advertisement advertisement)
        {
            throw new NotImplementedException();
        }
    }
}
