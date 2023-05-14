using Microsoft.AspNetCore.Identity;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace AdvertisingPortal.Core.Models.Domains
{
    public class ApplicationUser : IdentityUser
    {

        public ApplicationUser()
        {
            Advertisements = new Collection<Advertisement>();
            Pictures = new Collection<Picture>();
            MessagesAsSender = new Collection<Message>();
            MessagesAsReceiver = new Collection<Message>();
        }

        public ICollection<Advertisement> Advertisements { get; set; }
        public ICollection<Picture> Pictures { get; set; }
        public ICollection<Message> MessagesAsSender { get; set; }
        public ICollection<Message> MessagesAsReceiver { get; set; }




    }
}
