using AdvertisingPortal.Core.Models.Domains;

namespace AdvertisingPortal.Core.ViewModels
{
    public class CreateAdvertisementViewModel
    {
        public CreateAdvertisementViewModel(Advertisement advertisement, IEnumerable<Category> categories, string heading)
        {
            Advertisement = advertisement;
            Categories = categories;
            Heading = heading;
        }

        public Advertisement Advertisement { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public string Heading { get; set; }
    }
}
