using AdvertisingPortal.Core.Models.Domains;

namespace AdvertisingPortal.Core.Models.Repositories
{
    public interface IPictureRepository
    {
        void Add(IEnumerable<Picture> pictures);
    }
}
