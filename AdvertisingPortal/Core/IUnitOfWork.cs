using AdvertisingPortal.Core.Models.Repositories;

namespace AdvertisingPortal.Core
{
    public interface IUnitOfWork
    {
        IAdvertisementRepository Advertisement { get; set; }
        ICategoryRepository Category { get; set; }
        void Complete();
    }
}
