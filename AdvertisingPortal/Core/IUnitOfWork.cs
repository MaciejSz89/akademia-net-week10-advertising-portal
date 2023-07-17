using AdvertisingPortal.Core.Models.Repositories;

namespace AdvertisingPortal.Core
{
    public interface IUnitOfWork
    {
        IAdvertisementRepository Advertisement { get; set; }
        ICategoryRepository Category { get; set; }
        IPictureRepository Picture { get; set; }
        IMessageRepository Message { get; set; }
        void Complete();
    }
}
