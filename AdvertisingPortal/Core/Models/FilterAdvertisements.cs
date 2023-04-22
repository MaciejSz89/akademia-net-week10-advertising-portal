using AdvertisingPortal.Core.Models.Domains;
using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace AdvertisingPortal.Core.Models
{
    public class FilterAdvertisements
    {
        public FilterAdvertisements()
        {
            Categories = new Collection<FilterCategory>();
        }
        public string? Text { get; set; }

        public ICollection<FilterCategory> Categories { get; set; }

        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set;}
    }
}
