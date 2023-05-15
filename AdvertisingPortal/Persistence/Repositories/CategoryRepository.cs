using AdvertisingPortal.Core;
using AdvertisingPortal.Core.Models.Domains;
using AdvertisingPortal.Core.Models.Repositories;

namespace AdvertisingPortal.Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private IApplicationDbContext _context;
        public CategoryRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetCategories()
        {
            var categories = new List<Category>
            {
                new Category("Meble")
                {
                    Id = 1
                },
                new Category("Zwierzęta")
                {
                    Id = 2
                },
                new Category("Ogród")
                {
                    Id = 3
                }
            };

            

            return categories;
        }
    }
}
