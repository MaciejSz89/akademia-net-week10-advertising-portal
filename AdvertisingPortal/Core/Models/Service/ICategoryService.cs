using AdvertisingPortal.Core.Models.Domains;

namespace AdvertisingPortal.Core.Models.Service
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();
    }
}
