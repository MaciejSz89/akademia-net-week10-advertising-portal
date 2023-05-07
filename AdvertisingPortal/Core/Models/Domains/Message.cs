using System.ComponentModel.DataAnnotations;

namespace AdvertisingPortal.Core.Models.Domains
{
    public class Message
    {
        public int Id { get; set; }
        public DateTime SendTime { get; set; }
        public string? Content { get; set; }

        [Required]
        public string? SenderId { get; set; }

        [Required]
        public string? ReceiverId { get; set; }
        public int ConversationId { get; set; }
        public ApplicationUser? Sender { get; set; }
        public ApplicationUser? Receiver { get; set; }
        public Conversation? Conversation { get; set; }

    }
}
