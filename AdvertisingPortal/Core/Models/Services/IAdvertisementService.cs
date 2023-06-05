using AdvertisingPortal.Core.Models.Domains;

namespace AdvertisingPortal.Core.Models.Services
{
    public interface IAdvertisementService
    {
        void AddAdvertisement(Advertisement advertisement);
        Advertisement GetAdvertisement(int id);
        Advertisement GetAdvertisement(string userId, int advertisementId);
        void UpdateAdvertisement(Advertisement advertisement);

        IEnumerable<Advertisement> GetAdvertisements();
        IEnumerable<Advertisement> GetAdvertisements(string userId);
        void AddPicturesToAdvertisement(Advertisement advertisement, IEnumerable<IFormFile> images);
        IEnumerable<Advertisement> GetAdvertisements(GetAdvertisementsParams getAdvertisementParams);
    }
}
