using AdvertisingPortal.Core.Models;
using AdvertisingPortal.Core.Models.Domains;

namespace AdvertisingPortal.Core.ViewModels
{
    public class AdvertisementsViewModel
    {
        public AdvertisementsViewModel(FilterAdvertisements filter, IEnumerable<Advertisement> advertisements)
        {
            Filter = filter;
            Advertisements = advertisements;
        }

        public FilterAdvertisements Filter { get; set; }
        public IEnumerable<Advertisement> Advertisements { get; set; }
    }
}
