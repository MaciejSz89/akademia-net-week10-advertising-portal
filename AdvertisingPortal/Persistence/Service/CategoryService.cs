using AdvertisingPortal.Core.Models.Domains;
using AdvertisingPortal.Core.Models.Service;

namespace AdvertisingPortal.Persistence.Service
{
    public class CategoryService : ICategoryService
    {
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
