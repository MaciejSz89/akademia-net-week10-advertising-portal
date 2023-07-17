using System.ComponentModel.DataAnnotations;

namespace AdvertisingPortal.Core.Models.Domains
{
    public class Message
    {
        public int Id { get; set; }
        public DateTime SendTime { get; set; }

        [Display (Name = "Wiadomość")]
        public string? Content { get; set; }
        public bool IsRead { get; set; }


        [Required]
        public string? SenderId { get; set; }

        [Required]
        public string? ReceiverId { get; set; }
        public int AdvertisementId { get; set; }
        public ApplicationUser? Sender { get; set; }
        public ApplicationUser? Receiver { get; set; }
        public Advertisement? Advertisement { get; set; } 

    }
}
