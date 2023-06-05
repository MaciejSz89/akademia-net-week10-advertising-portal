using AdvertisingPortal.Core.Models;
using AdvertisingPortal.Core.Models.Domains;

namespace AdvertisingPortal.Core.ViewModels
{
    public class AdvertisementsViewModel
    {
        public AdvertisementsViewModel(FilterAdvertisements filterAdvertisements, 
                                       SortAdvertisements sortAdvertisements, 
                                       IEnumerable<Advertisement>? advertisements,
                                       IEnumerable<Category>? categories)
        {
            FilterAdvertisements = filterAdvertisements;
            SortAdvertisements = sortAdvertisements;
            Advertisements = advertisements;
            Categories = categories;
        }

        public FilterAdvertisements FilterAdvertisements { get; set; }
        public SortAdvertisements SortAdvertisements { get; set; }
        public IEnumerable<Advertisement>? Advertisements { get; set; }
        public IEnumerable<Category>? Categories { get; set; }

    }
}
