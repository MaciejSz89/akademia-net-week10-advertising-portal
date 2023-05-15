using AdvertisingPortal.Core.Models.Domains;

namespace AdvertisingPortal.Core.Models.Repositories
{
    public interface IAdvertisementRepository
    {
        void AddAdvertisement(Advertisement advertisement);
        Advertisement GetAdvertisement(string userId, int advertisementId);
        void UpdateAdvertisement(Advertisement advertisement);
    }
}
