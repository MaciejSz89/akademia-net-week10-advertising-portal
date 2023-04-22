using AdvertisingPortal.Core.Models.Domains;

namespace AdvertisingPortal.Core.Models
{
    public class FilterCategory
    {
        public FilterCategory(Category category)
        {
            CategoryId = category.Id;
            CategoryName = category.Name;
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool IsSelected { get; set; }
    }
}
