using AdvertisingPortal.Core.Models.Domains;

namespace AdvertisingPortal.Core.Models.Services
{
    public interface IMessageService
    {
        void SendMessage(Message message);
        IEnumerable<Conversation> GetConversations(string userId);
        Conversation GetConversation(string userId, string interlocutorId, int advertisementId);
    }
}
