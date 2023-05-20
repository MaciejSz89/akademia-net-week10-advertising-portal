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
        }

        public IAdvertisementRepository Advertisement { get; set; }
        public ICategoryRepository Category { get; set; }

        public void Complete()
        {
           _context.SaveChanges();
        }
    }
}
