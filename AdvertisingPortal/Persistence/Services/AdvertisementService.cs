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
            _unitOfWork.Advertisement.AddAdvertisement(advertisement);
        }

        public Advertisement GetAdvertisement(string userId, int advertisementId)
        {
            return _unitOfWork.Advertisement.GetAdvertisement(userId, advertisementId);
        }

        public void UpdateAdvertisement(Advertisement advertisement)
        {
            _unitOfWork.Advertisement.UpdateAdvertisement(advertisement);
        }
    }
}
