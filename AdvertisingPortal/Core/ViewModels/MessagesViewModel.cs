using AdvertisingPortal.Core.Models.Domains;

namespace AdvertisingPortal.Core.ViewModels
{
    public class MessagesViewModel
    {
        public MessagesViewModel(ICollection<Message> messages, ApplicationUser user, ApplicationUser interlocutor)
        {
            Messages = messages;
            User = user;
            Interlocutor = interlocutor;
            Message = new Message();
        }

        public ICollection<Message> Messages { get; set; }
        public Message Message { get; set; }
        public ApplicationUser User { get; set; }
        public ApplicationUser Interlocutor { get; set; }
        
    }
}
