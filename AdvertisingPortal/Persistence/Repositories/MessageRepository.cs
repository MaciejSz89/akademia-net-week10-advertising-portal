using AdvertisingPortal.Core;
using AdvertisingPortal.Core.Models;
using AdvertisingPortal.Core.Models.Domains;
using AdvertisingPortal.Core.Models.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AdvertisingPortal.Persistence.Repositories
{
    public class MessageRepository : IMessageRepository
    {

        private IApplicationDbContext _context;
        public MessageRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateMessage(Message message)
        {
            _context.Messages.Add(message);
        }

        public IEnumerable<Message> GetMessages(string userId, string interlocutorId, int advertisementId)
        {
            return _context.Messages.Where(x => ((x.SenderId == userId && x.ReceiverId == interlocutorId)
                                              || (x.ReceiverId == userId && x.SenderId == interlocutorId))
                                              && x.AdvertisementId == advertisementId)
                                    .Include(x => x.Advertisement)
                                    .Include(x => x.Sender)
                                    .Include(x => x.Receiver)
                                    .OrderBy(x => x.SendTime)
                                    .ToList();
        }

        public IEnumerable<Message> GetMessages(string userId)
        {


            return _context.Messages.Where(x => x.SenderId == userId || x.ReceiverId == userId)
                                                .Include(x => x.Sender)
                                                .Include(x => x.Receiver)
                                                .Include(x => x.Advertisement)
                                                .ToList();                                           

        }

    }
}
