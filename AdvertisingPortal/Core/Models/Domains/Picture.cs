using System.ComponentModel.DataAnnotations;

namespace AdvertisingPortal.Core.Models.Domains
{
    public class Picture
    {

        public Picture(byte[] image)
        {
            Image = image;
        }

        public int Id { get; set; }

        public byte[] Image { get; set; }

        public bool IsMainPicture { get; set; }
        
        [Required]
        public string? FileName { get; set; }
        public int AdvertisementId { get; set; }       

        [Required]
        public string? UserId { get; set; }

        public Advertisement? Advertisement { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
