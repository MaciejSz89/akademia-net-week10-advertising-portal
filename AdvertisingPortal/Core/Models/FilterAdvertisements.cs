using AdvertisingPortal.Core.Models.Domains;
using Microsoft.VisualBasic;
using System.Collections.ObjectModel;

namespace AdvertisingPortal.Core.Models
{
    public class FilterAdvertisements
    {
        public FilterAdvertisements()
        {
            CategoryIds = new Collection<int>();
        }
        public string? Text { get; set; }

        public ICollection<int> CategoryIds { get; set; }
    }
}
