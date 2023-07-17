using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvertisingPortal.Core.Models.Domains
{
    public class Category
    {
        public Category()
        {
            Advertisements = new Collection<Advertisement>();
        }
        public int Id { get; set; }

        [Display(Name = "Nazwa")]
        [Required(ErrorMessage = "Pole Nazwa jest wymagane")]
        public string? Name { get; set; }

        public ICollection<Advertisement> Advertisements { get; set; }
    }
}
