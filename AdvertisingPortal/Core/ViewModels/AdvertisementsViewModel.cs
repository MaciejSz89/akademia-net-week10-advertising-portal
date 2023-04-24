using AdvertisingPortal.Core.Models;
using AdvertisingPortal.Core.Models.Domains;

namespace AdvertisingPortal.Core.ViewModels
{
    public class AdvertisementsViewModel
    {
        public AdvertisementsViewModel(FilterAdvertisements filterAdvertisements, IEnumerable<Advertisement> advertisements)
        {
            FilterAdvertisements = filterAdvertisements;
            Advertisements = advertisements;
        }

        public FilterAdvertisements FilterAdvertisements { get; set; }
        public IEnumerable<Advertisement> Advertisements { get; set; }
        public SortAdvertisements SortAdvertisements { get; set; }
    }
}
