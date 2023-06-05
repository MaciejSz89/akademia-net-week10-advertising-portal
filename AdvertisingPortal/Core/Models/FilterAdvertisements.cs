using AdvertisingPortal.Core.Models.Domains;
using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace AdvertisingPortal.Core.Models
{
    public class FilterAdvertisements
    {

        public string? Text { get; set; }

        public ICollection<int>? Categories { get; set; }

        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set;}
    }
}
