using Microsoft.AspNetCore.Identity;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace AdvertisingPortal.Core.Models.Domains
{
    public class ApplicationUser : IdentityUser
    {

        public ApplicationUser(string nickname)
        {
            Advertisements = new Collection<Advertisement>();
            Nickname = nickname;
        }


        [Display(Name = "Nazwa")]
        [Required(ErrorMessage = "Pole Nazwa jest wymagane")]
        public string Nickname { get; set; }

        public ICollection<Advertisement> Advertisements { get; set; }

    }
}
