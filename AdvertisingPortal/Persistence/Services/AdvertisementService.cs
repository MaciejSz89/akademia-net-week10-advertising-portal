using AdvertisingPortal.Core;
using AdvertisingPortal.Core.Models;
using AdvertisingPortal.Core.Models.Domains;
using AdvertisingPortal.Core.Models.Services;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;

namespace AdvertisingPortal.Persistence.Services
{
    public class AdvertisementService : IAdvertisementService
    {
        private IUnitOfWork _unitOfWork;

        public AdvertisementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddAdvertisement(Advertisement advertisement, IEnumerable<IFormFile> images, int? mainPictureId)
        {

            AddPicturesToAdvertisement(advertisement, images, mainPictureId, null);

            if (advertisement.Id == 0)
            {
                advertisement.DateOfPublication = DateTime.UtcNow;
            }

            _unitOfWork.Advertisement.AddAdvertisement(advertisement);
            _unitOfWork.Complete();
        }

        private void AddPicturesToAdvertisement(Advertisement advertisement, IEnumerable<IFormFile> images, int? mainPictureId, IEnumerable<int>? picturesToDeleteId)
        {

            if (advertisement.Id != 0)
                advertisement.Pictures = _unitOfWork.Picture.GetPictures(advertisement.UserId, advertisement.Id);


            if (picturesToDeleteId != null && picturesToDeleteId.Any())
            {
                _unitOfWork.Picture.DeletePictures(advertisement.UserId, picturesToDeleteId);
                advertisement.Pictures = advertisement.Pictures
                                                          .GroupJoin(picturesToDeleteId, x => x.Id, y => y, (x, y) => new { p = x, pd = y })
                                                          .Where(x => x.pd.Count() == 0)
                                                          .Select(x => x.p)
                                                          .ToList();

            }



            AddNewPicturesToAdvertisement(advertisement, images);

            SetMainPicture(advertisement.Pictures, mainPictureId);

        }

        private void AddNewPicturesToAdvertisement(Advertisement advertisement, IEnumerable<IFormFile> images)
        {
            if (images != null && images.Any())
            {
                foreach (var image in images)
                {
                    using var stream = new MemoryStream();
                    image.CopyTo(stream);
                    var picture = new Picture(stream.ToArray());
                    picture.FileName = image.FileName;
                    picture.UserId = advertisement.UserId;
                    advertisement.Pictures.Add(picture);
                }
            }
        }

        private void SetMainPicture(IEnumerable<Picture> pictures, int? mainPictureId)
        {
            if (pictures == null || !pictures.Any())
                return;

            foreach (var picture in pictures)
            {
                picture.IsMainPicture = false;
            }

            if (mainPictureId != null && mainPictureId != 0 && pictures.SingleOrDefault(x => x.Id == mainPictureId) != null)
            {
                pictures.Single(x => x.Id == mainPictureId).IsMainPicture = true;
                return;
            }


            pictures.First().IsMainPicture = true;


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

        public IEnumerable<Advertisement> GetAdvertisements(string userId)
        {
            return _unitOfWork.Advertisement.GetAdvertisements(userId);
        }

        public IEnumerable<Advertisement> GetAdvertisements(GetAdvertisementsParams getAdvertisementParams)
        {
            return _unitOfWork.Advertisement.GetAdvertisements(getAdvertisementParams);
        }

        public void UpdateAdvertisement(Advertisement advertisement, IEnumerable<IFormFile> images, IEnumerable<int> picturesToDeleteId, int? mainPictureId)
        {

            AddPicturesToAdvertisement(advertisement, images, mainPictureId, picturesToDeleteId);


            _unitOfWork.Advertisement.UpdateAdvertisement(advertisement);
            _unitOfWork.Complete();
        }

        public void DeleteAdvertisement(int id, string userId)
        {
            _unitOfWork.Advertisement.DeleteAdvertisement(id, userId);
            _unitOfWork.Complete();
        }
    }
}
