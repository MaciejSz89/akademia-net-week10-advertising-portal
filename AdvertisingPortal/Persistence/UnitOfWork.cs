using AdvertisingPortal.Core;
using AdvertisingPortal.Core.Models.Repositories;
using AdvertisingPortal.Persistence.Repositories;

namespace AdvertisingPortal.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IApplicationDbContext _context;

        public UnitOfWork(IApplicationDbContext context)
        {
            _context = context;
            Advertisement = new AdvertisementRepository(context);
            Category = new CategoryRepository(context);
            Picture = new PictureRepository(context);
            Message = new MessageRepository(context);            
        }

        public IAdvertisementRepository Advertisement { get; set; }
        public ICategoryRepository Category { get; set; }
        public IPictureRepository Picture { get; set; }
        public IMessageRepository Message { get; set; }

        public void Complete()
        {
           _context.SaveChanges();
        }
    }
}
