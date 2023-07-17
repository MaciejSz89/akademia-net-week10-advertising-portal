using AdvertisingPortal.Core.Models.Domains;

namespace AdvertisingPortal.Core.Models.Services
{
    public interface IAdvertisementService
    {
        void AddAdvertisement(Advertisement advertisement, IEnumerable<IFormFile> images, int? mainPictureId);
        Advertisement GetAdvertisement(int id);
        Advertisement GetAdvertisement(string userId, int advertisementId);
        void UpdateAdvertisement(Advertisement advertisement, IEnumerable<IFormFile> images, IEnumerable<int> picturesToDeleteId, int? mainPictureId);

        IEnumerable<Advertisement> GetAdvertisements();
        IEnumerable<Advertisement> GetAdvertisements(string userId);
        IEnumerable<Advertisement> GetAdvertisements(GetAdvertisementsParams getAdvertisementParams);
        public void DeleteAdvertisement(int id, string userId);
    }
}
