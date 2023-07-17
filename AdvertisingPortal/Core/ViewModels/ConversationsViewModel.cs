using AdvertisingPortal.Core.Models;

namespace AdvertisingPortal.Core.ViewModels
{
    public class ConversationsViewModel
    {
        public string? UserId { get; set; }
        public IEnumerable<Conversation>? Conversations { get; set; }
    }
}
