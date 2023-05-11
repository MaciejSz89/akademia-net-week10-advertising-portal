using AdvertisingPortal.Core.Models.Domains;

namespace AdvertisingPortal.Core.ViewModels
{
    public class ConversationViewModel
    {
        public ConversationViewModel(Conversation conversation, ApplicationUser user, ApplicationUser interlocutor)
        {
            Conversation = conversation;
            User = user;
            Interlocutor = interlocutor;
        }

        public Conversation Conversation { get; set; }
        public ApplicationUser User { get; set; }
        public ApplicationUser Interlocutor { get; set; }
    }
}
