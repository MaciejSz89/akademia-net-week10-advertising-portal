namespace AdvertisingPortal.Core.Models
{
    public class GetAdvertisementsParams
    {
        public GetAdvertisementsParams(FilterAdvertisements filterAdvertisements, SortAdvertisements sortAdvertisements)
        {
            Text = filterAdvertisements.Text;
            PriceFrom = filterAdvertisements.PriceFrom;
            PriceTo = filterAdvertisements.PriceTo;
            CategoryIds = filterAdvertisements.Categories;
            SortAdvertisements = sortAdvertisements;
        }
        public string? Text { get; set; }
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }
        public IEnumerable<int>? CategoryIds { get; set; }
        public SortAdvertisements SortAdvertisements { get; set; }
    }
}
