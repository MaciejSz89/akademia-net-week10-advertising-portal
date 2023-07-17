using AdvertisingPortal.Core.Models.Domains;

namespace AdvertisingPortal.Core.Models.Repositories
{
    public interface IMessageRepository
    {
        void CreateMessage(Message message);
        IEnumerable<Message> GetMessages(string userId, string interlocutorId, int advertisementId);
        IEnumerable<Message> GetMessages(string userId);
    }
}
