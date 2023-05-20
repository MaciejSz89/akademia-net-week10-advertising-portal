using AdvertisingPortal.Core.Models.Domains;

namespace AdvertisingPortal.Core.Models
{
    public class FilterCategory
    {
        public FilterCategory(int categoryId, string? categoryName)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
            IsSelected = true;
        }

        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public bool IsSelected { get; set; }
    }
}
