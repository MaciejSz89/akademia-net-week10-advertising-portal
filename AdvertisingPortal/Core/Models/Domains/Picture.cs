namespace AdvertisingPortal.Core.Models.Domains
{
    public class Picture
    {
        public int Id { get; set; }

        public byte[] Image { get; set; }

        public bool IsMainPicture { get; set; }

        public int AdvertisementId { get; set; }

        public int UserId { get; set; }

        public Advertisement Advertisement { get; set; }
        public ApplicationUser User { get; set; }
    }
}
