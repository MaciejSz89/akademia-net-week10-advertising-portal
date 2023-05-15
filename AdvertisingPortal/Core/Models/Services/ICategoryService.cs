using AdvertisingPortal.Core.Models.Domains;

namespace AdvertisingPortal.Core.Models.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();
    }
}
