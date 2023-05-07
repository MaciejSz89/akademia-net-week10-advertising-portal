using Microsoft.Build.Framework;
using System.Collections.ObjectModel;

namespace AdvertisingPortal.Core.Models.Domains
{
    public class Conversation
    {
        public Conversation()
        {
            Messages = new Collection<Message>();
        }
        public int Id { get; set; }

        [Required]
        public string? AdvertiserId { get; set; }

        [Required]
        public string? AdRecipientId { get; set; }
        public ApplicationUser? Advertiser { get; set; }
        public ApplicationUser? AdRecipient { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
