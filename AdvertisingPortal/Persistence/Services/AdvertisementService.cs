using AdvertisingPortal.Core;
using AdvertisingPortal.Core.Models.Domains;
using AdvertisingPortal.Core.Models.Services;

namespace AdvertisingPortal.Persistence.Services
{
    public class AdvertisementService : IAdvertisementService
    {
        private IUnitOfWork _unitOfWork;

        public AdvertisementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddAdvertisement(Advertisement advertisement)
        {
            if (advertisement.Pictures != null && !advertisement.Pictures.Where(x => x.IsMainPicture).Any())
                advertisement.Pictures.First().IsMainPicture = true;

            _unitOfWork.Advertisement.AddAdvertisement(advertisement);
            _unitOfWork.Complete();
        }
        public Advertisement GetAdvertisement(int id)
        {
            return _unitOfWork.Advertisement.GetAdvertisement(id);
        }

        public Advertisement GetAdvertisement(string userId, int advertisementId)
        {
            return _unitOfWork.Advertisement.GetAdvertisement(userId, advertisementId);
        }

        public IEnumerable<Advertisement> GetAdvertisements()
        {
            return _unitOfWork.Advertisement.GetAdvertisements();
        }

        public void UpdateAdvertisement(Advertisement advertisement)
        {
            _unitOfWork.Advertisement.UpdateAdvertisement(advertisement);
            _unitOfWork.Complete();
        }
    }
}
