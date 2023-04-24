using System.ComponentModel.DataAnnotations;

namespace AdvertisingPortal.Core.Models
{
    public enum SortAdvertisements
    {
        [Display(Name = "Od najnowszych")]
        ByDateOfPublicationDescending,
        [Display(Name = "Od najstarszych")]
        ByDateOfPublicationAscending,
        [Display(Name = "Cena rosnąco")]
        ByPriceAscending,
        [Display(Name = "Cena malejąco")]
        ByPriceDescending
    }
}
