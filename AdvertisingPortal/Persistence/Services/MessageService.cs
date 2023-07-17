using AdvertisingPortal.Core;
using AdvertisingPortal.Core.Models;
using AdvertisingPortal.Core.Models.Domains;
using AdvertisingPortal.Core.Models.Services;

namespace AdvertisingPortal.Persistence.Services
{
    public class MessageService : IMessageService
    {
        private IUnitOfWork _unitOfWork;

        public MessageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Conversation GetConversation(string userId, string interlocutorId, int advertisementId)
        {
            var messages = _unitOfWork.Message
                                      .GetMessages(userId, interlocutorId, advertisementId);

            if (messages is null || !messages.Any())
                return new Conversation
                {
                    AdvertisementId = advertisementId,
                    UserId = userId,
                    InterlocutorId = interlocutorId
                };

            return new Conversation
            {
                AdvertisementId = advertisementId,
                Advertisement = messages.First().Advertisement,
                UserId = userId,
                User = messages.First().SenderId == userId ? messages.First().Sender : messages.First().Receiver,
                InterlocutorId = interlocutorId,
                Interlocutor = messages.First().SenderId == interlocutorId ? messages.First().Sender : messages.First().Receiver,              
                Messages = messages
            };
        }

        public IEnumerable<Conversation> GetConversations(string userId)
        {
            var messages = _unitOfWork.Message.GetMessages(userId);

            return messages.Select(x => new
                                        {
                                            User = x.SenderId == userId ? x.Sender : x.Receiver,
                                            UserId = x.SenderId == userId ? x.SenderId : x.ReceiverId,
                                            Interlocutor = x.SenderId == userId ? x.Receiver : x.Sender,
                                            InterlocutorId = x.SenderId == userId ? x.ReceiverId : x.SenderId,
                                            Advertisement = x.Advertisement,
                                            AdvertisementId = x.AdvertisementId,
                                            Message = x
                                        })
                           .OrderBy(x => x.Message.SendTime)
                           .GroupBy(x => new
                                         {
                                             x.User,
                                             x.UserId,
                                             x.Interlocutor,
                                             x.InterlocutorId,
                                             x.Advertisement,
                                             x.AdvertisementId
                                         },
                                    x => x.Message)
                           .Select(x => new Conversation
                                        {
                                            Advertisement = x.Key.Advertisement,
                                            AdvertisementId = x.Key.AdvertisementId,
                                            Interlocutor = x.Key.Interlocutor,
                                            InterlocutorId = x.Key.InterlocutorId,
                                            User = x.Key.User,
                                            UserId = x.Key.UserId,
                                            Messages = x.AsEnumerable()
                                        })
                           .OrderByDescending(x => x.Messages?.Last().SendTime)
                           .ToList();

        }

        public void SendMessage(Message message)
        {
            message.SendTime = DateTime.UtcNow;
            _unitOfWork.Message.CreateMessage(message);
            _unitOfWork.Complete();
        }
    }
}
