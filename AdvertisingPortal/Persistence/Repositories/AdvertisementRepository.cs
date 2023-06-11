using AdvertisingPortal.Core;
using AdvertisingPortal.Core.Models;
using AdvertisingPortal.Core.Models.Domains;
using AdvertisingPortal.Core.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
            if (advertisement.Pictures != null
             && advertisement.Pictures.Any()
             && advertisement.Pictures.Count(x => x.IsMainPicture) > 1)
                throw new ArgumentException("More than one picture set as main");

            if (advertisement.Pictures != null
             && advertisement.Pictures.Any()
             && advertisement.Pictures.Count(x => x.IsMainPicture) == 0)
                throw new ArgumentException("None picture set as main");

            _context.Advertisements.Add(advertisement);
        }

        public void DeleteAdvertisement(int id, string userId)
        {
            var advertisementToDelete = _context.Advertisements
                                                .Include(x => x.Pictures)
                                                .Single(x => x.Id == id
                                                          && x.UserId == userId);
            _context.Advertisements.Remove(advertisementToDelete);
        }

        public Advertisement GetAdvertisement(string userId, int advertisementId)
        {
            return _context.Advertisements
                           .Include(x => x.User)
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

        public IEnumerable<Advertisement> GetAdvertisements(GetAdvertisementsParams getAdvertisementParams)
        {
            var advertisementsQuery = _context.Advertisements
                                              .Include(x => x.Pictures)
                                              .Include(x => x.User)
                                              .AsQueryable();

            if (getAdvertisementParams.PriceFrom != null)
                advertisementsQuery = advertisementsQuery.Where(x => x.Price >= getAdvertisementParams.PriceFrom);

            if (getAdvertisementParams.PriceTo != null && getAdvertisementParams.PriceTo > 0)
                advertisementsQuery = advertisementsQuery.Where(x => x.Price <= getAdvertisementParams.PriceTo);


            if (!string.IsNullOrWhiteSpace(getAdvertisementParams.Text))
                advertisementsQuery = advertisementsQuery.Where(x => x.Title != null
                                                                  && x.Title.ToUpper().Contains(getAdvertisementParams.Text.ToUpper()));

            if (getAdvertisementParams.CategoryIds != null && getAdvertisementParams.CategoryIds.Any())
                advertisementsQuery = advertisementsQuery.Where(x => getAdvertisementParams.CategoryIds.Contains(x.CategoryId));

            switch (getAdvertisementParams.SortAdvertisements)
            {
                case SortAdvertisements.ByDateOfPublicationDescending:
                    advertisementsQuery = advertisementsQuery.OrderByDescending(x => x.DateOfPublication);
                    break;
                case SortAdvertisements.ByDateOfPublicationAscending:
                    advertisementsQuery = advertisementsQuery.OrderBy(x => x.DateOfPublication);
                    break;
                case SortAdvertisements.ByPriceAscending:
                    advertisementsQuery = advertisementsQuery.OrderBy(x => x.Price);
                    break;
                case SortAdvertisements.ByPriceDescending:
                    advertisementsQuery = advertisementsQuery.OrderByDescending(x => x.Price);
                    break;
                default:
                    break;
            }


            return advertisementsQuery.ToList();
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
