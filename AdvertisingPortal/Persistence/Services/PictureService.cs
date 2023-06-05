using AdvertisingPortal.Core;
using AdvertisingPortal.Core.Models.Domains;
using AdvertisingPortal.Core.Models.Services;
using System.Collections.ObjectModel;

namespace AdvertisingPortal.Persistence.Services
{
    public class PictureService : IPictureService
    {
        private IUnitOfWork _unitOfWork;

        public PictureService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddPictures(string userId, int advertisementId, IEnumerable<IFormFile> images)
        {
            var pictures = new Collection<Picture>();

            foreach (var image in images)
            {
                using var stream = new MemoryStream();
                image.CopyTo(stream);
                var picture = new Picture(stream.ToArray());
                picture.FileName = image.FileName;
                picture.UserId = userId;
                picture.AdvertisementId = advertisementId;
                pictures.Add(picture);
            }

            _unitOfWork.Picture.Add(pictures);

            _unitOfWork.Complete();
        }

        public void DeletePictures(string userId, IEnumerable<int> picturesToDeleteId)
        {
            _unitOfWork.Picture.DeletePictures(userId, picturesToDeleteId);

            _unitOfWork.Complete();
        }
    }
}
