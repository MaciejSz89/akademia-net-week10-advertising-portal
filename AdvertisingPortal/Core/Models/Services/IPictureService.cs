namespace AdvertisingPortal.Core.Models.Services
{
    public interface IPictureService
    {
        void AddPictures(string userId, int advertisementId, IEnumerable<IFormFile> images);
    }
}
