using AdvertisingPortal.Core.Models;
using AdvertisingPortal.Core.Models.Domains;
using AdvertisingPortal.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using IWebHostEnvironment = Microsoft.AspNetCore.Hosting.IWebHostEnvironment;

namespace AdvertisingPortal.Controllers
{
    public class AdvertisementController : Controller
    {
        private IWebHostEnvironment Environment;
        public AdvertisementController(IWebHostEnvironment _environment)
        {
            Environment = _environment;
        }
        public IActionResult Advertisements()
        {

            
            var advertisements = new List<Advertisement>
            {
                new Advertisement("jndafkjfd0")
                {
                    User = new ApplicationUser("Adam"),
                    Category = new Category("Meble"),
                    Title = "Sprzedam laptopa",
                    Pictures = new List<Picture>
                    {
                        new Picture(System.IO.File.ReadAllBytes(Path.Combine(this.Environment.WebRootPath, "img/") + "laptop.jpg"), "jndafkjfd0")
                        {
                            IsMainPicture = true
                        }
                    },
                    Price = 3000.0M,
                    DateOfPublication= DateTime.Now,
                    Location = "Wiry"

                },
                new Advertisement("jndafkjfd0")
                {
                    User = new ApplicationUser("Adam"),
                    Category = new Category("Meble"),
                    Title = "Sprzedam laptopa",
                    Pictures = new List<Picture>
                    {
                        new Picture(System.IO.File.ReadAllBytes(Path.Combine(this.Environment.WebRootPath, "img/") + "laptop.jpg"), "jndafkjfd0")
                        {
                            IsMainPicture = true
                        }
                    },
                    Price = 3000.0M,
                    DateOfPublication= DateTime.Now,
                    Location = "Wiry"

                },
                new Advertisement("jndafkjfd0")
                {
                    User = new ApplicationUser("Adam"),
                    Category = new Category("Meble"),
                    Title = "Sprzedam laptopa",
                    Pictures = new List<Picture>
                    {
                        new Picture(System.IO.File.ReadAllBytes(Path.Combine(this.Environment.WebRootPath, "img/") + "laptop.jpg"), "jndafkjfd0")
                        {
                            IsMainPicture = true
                        }
                    },
                    Price = 3000.0M,
                    DateOfPublication= DateTime.Now,
                    Location = "Wiry"

                },
                new Advertisement("jndafkjfd0")
                {
                    User = new ApplicationUser("Adam"),
                    Category = new Category("Meble"),
                    Title = "Sprzedam laptopa",
                    Pictures = new List<Picture>
                    {
                        new Picture(System.IO.File.ReadAllBytes(Path.Combine(this.Environment.WebRootPath, "img/") + "laptop.jpg"), "jndafkjfd0")
                        {
                            IsMainPicture = true
                        }
                    },
                    Price = 3000.0M,
                    DateOfPublication= DateTime.Now,
                    Location = "Wiry"

                },
                new Advertisement("jndafkjfd0")
                {
                    User = new ApplicationUser("Adam"),
                    Category = new Category("Meble"),
                    Title = "Sprzedam laptopa",
                    Pictures = new List<Picture>
                    {
                        new Picture(System.IO.File.ReadAllBytes(Path.Combine(this.Environment.WebRootPath, "img/") + "laptop.jpg"), "jndafkjfd0")
                        {
                            IsMainPicture = true
                        }
                    },
                    Price = 3000.0M,
                    DateOfPublication= DateTime.Now,
                    Location = "Wiry"

                }
            };



            var vm = new AdvertisementsViewModel(new FilterAdvertisements(), advertisements);

            return View(vm);
        }
    }
}
