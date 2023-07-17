using AdvertisingPortal.Core.Models.Domains;

namespace AdvertisingPortal.Core.Models.Repositories
{
    public interface IAdvertisementRepository
    {
        void AddAdvertisement(Advertisement advertisement);
        Advertisement GetAdvertisement(int id);
        Advertisement GetAdvertisement(string userId, int advertisementId);
        IEnumerable<Advertisement> GetAdvertisements();
        IEnumerable<Advertisement> GetAdvertisements(string userId);
        IEnumerable<Advertisement> GetAdvertisements(GetAdvertisementsParams getAdvertisementParams);
        void UpdateAdvertisement(Advertisement advertisement);
        public void DeleteAdvertisement(int id, string userId);
    }
}
