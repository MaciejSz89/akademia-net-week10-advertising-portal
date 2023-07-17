using AdvertisingPortal.Core.Models.Domains;

namespace AdvertisingPortal.Core.ViewModels
{
    public class ViewAdvertisementViewModel
    {
        public ViewAdvertisementViewModel(Advertisement advertisement, Message? message)
        {
            Advertisement = advertisement;
            Message = message;
        }
        public Advertisement Advertisement { get; set; }
        public Message? Message { get; set; }
    }
}
