using AdvertisingPortal.Core.Models.Domains;

namespace AdvertisingPortal.Core.Models.Repositories
{
    public interface IPictureRepository
    {
        void Add(IEnumerable<Picture> pictures);
        void DeletePictures(string? userId, IEnumerable<int> picturesToDeleteId);
        ICollection<Picture> GetPictures(string? userId, int advertisementId);
        void SetAsMainPicture(int id, string? userId);
    }
}
