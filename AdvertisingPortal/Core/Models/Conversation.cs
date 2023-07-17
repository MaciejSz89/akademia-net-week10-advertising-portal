using AdvertisingPortal.Core.Models.Domains;

namespace AdvertisingPortal.Core.Models
{
    public class Conversation
    {
        public string? UserId { get; set; }
        public string? InterlocutorId { get; set; }
        public int AdvertisementId { get; set; }
        public ApplicationUser? User { get; set; }
        public ApplicationUser? Interlocutor { get; set; }        
        public Advertisement? Advertisement { get; set; }
        public IEnumerable<Message>? Messages { get; set; }
    }
}
