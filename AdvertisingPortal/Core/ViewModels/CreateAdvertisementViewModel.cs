using AdvertisingPortal.Core.Models.Domains;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

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
