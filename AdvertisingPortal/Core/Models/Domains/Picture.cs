namespace AdvertisingPortal.Core.Models.Domains
{
    public class Picture
    {

        public Picture(byte[] image, string userId)
        {
            Image = image;
            UserId = userId;
        }

        public int Id { get; set; }

        public byte[] Image { get; set; }

        public bool IsMainPicture { get; set; }

        public int AdvertisementId { get; set; }

        public string UserId { get; set; }

        public Advertisement? Advertisement { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
