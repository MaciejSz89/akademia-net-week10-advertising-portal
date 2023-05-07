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
            Pictures = new Collection<Picture>();
            ConversationsAsAdvertiser = new Collection<Conversation>();
            ConversationsAsAdRecepient = new Collection<Conversation>();
            MessagesAsSender = new Collection<Message>();
            MessagesAsReceiver = new Collection<Message>();
            Nickname = nickname;
        }


        [Display(Name = "Nazwa")]
        [Required(ErrorMessage = "Pole Nazwa jest wymagane")]
        public string Nickname { get; set; }

        public ICollection<Advertisement> Advertisements { get; set; }
        public ICollection<Picture> Pictures { get; set; }
        public ICollection<Conversation> ConversationsAsAdvertiser { get; set; }
        public ICollection<Conversation> ConversationsAsAdRecepient { get; set; }
        public ICollection<Message> MessagesAsSender { get; set; }
        public ICollection<Message> MessagesAsReceiver { get; set; }




    }
}
