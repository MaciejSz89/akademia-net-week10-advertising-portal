using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvertisingPortal.Core.Models.Domains
{
    public class Advertisement
    {
        public Advertisement()
        {
            Pictures = new Collection<Picture>();
            Messages = new Collection<Message>();
        }
        public int Id { get; set; }



        [Display(Name = "Tytuł")]
        [Required(ErrorMessage = "Pole Tytuł jest wymagane")]
        public string? Title { get; set; }

        [Display(Name = "Opis")]
        [Required(ErrorMessage = "Pole Opis jest wymagane")]
        public string? Description { get; set; }

        [DataType(DataType.Currency)]
        [RegularExpression(@"^\d+(\,\d{1,2})?$")]
        //[DisplayFormat(DataFormatString = "{0:N2} zł")]
        [DisplayFormat(DataFormatString = "{0:N2} zł")]
        [Column(TypeName = "money")]
        [Display(Name = "Cena")]
        public decimal Price { get; set; }

        [Display(Name = "Miejscowość")]
        [Required(ErrorMessage = "Pole Miejscowość jest wymagane")]
        public string? Location { get; set; }

        [Display(Name = "Data dodania")]
        public DateTime DateOfPublication { get; set; }


        [Display(Name = "Kategoria")]
        [Required(ErrorMessage = "Pole Kategoria jest wymagane")]
        public int CategoryId { get; set; }

        [Required]
        public string? UserId { get; set; }

        public Category? Category { get; set; }
        public ApplicationUser? User { get; set; }

        public ICollection<Picture> Pictures { get; set; }
        public ICollection<Message> Messages { get; set; }

    }
}
