using AdvertisingPortal.Core.Models.Domains;

namespace AdvertisingPortal.Core.Models.Service
{
    public interface IAdvertisementService
    {
        void AddAdvertisement(Advertisement advertisement);
        Advertisement GetAdvertisement(string userId, int advertisementId);
        void UpdateAdvertisement(Advertisement advertisement);
    }
}
