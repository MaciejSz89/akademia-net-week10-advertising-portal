using AdvertisingPortal.Core.Models.Domains;

namespace AdvertisingPortal.Core.Models.Services
{
    public interface IMessageService
    {
        void SendMessage(Message message);
    }
}
