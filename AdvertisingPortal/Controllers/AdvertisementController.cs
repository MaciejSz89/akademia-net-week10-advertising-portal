using AdvertisingPortal.Core.Models;
using AdvertisingPortal.Core.Models.Domains;
using AdvertisingPortal.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using System.Drawing;
using IWebHostEnvironment = Microsoft.AspNetCore.Hosting.IWebHostEnvironment;

namespace AdvertisingPortal.Controllers
{

    [Authorize]
    public class AdvertisementController : Controller
    {
        private IWebHostEnvironment Environment;


        public AdvertisementController(IWebHostEnvironment _environment)
        {
            Environment = _environment;
        }

        [AllowAnonymous]
        public IActionResult Advertisements()
        {


            var advertisements = new List<Advertisement>
            {
                new Advertisement()
                {
                    User = new ApplicationUser("Adam"),
                    Category = new Category("Meble"),
                    Title = "Sprzedam laptopa",
                    Pictures = new List<Picture>
                    {
                        new Picture(System.IO.File.ReadAllBytes(Path.Combine(this.Environment.WebRootPath, "img/") + "laptop.jpg"))
                        {
                            IsMainPicture = true
                        }
                    },
                    Price = 3000.0M,
                    DateOfPublication= DateTime.Now,
                    Location = "Wiry"

                },
                new Advertisement()
                {
                    User = new ApplicationUser("Adam"),
                    Category = new Category("Meble"),
                    Title = "Sprzedam laptopa",
                    Pictures = new List<Picture>
                    {
                        new Picture(System.IO.File.ReadAllBytes(Path.Combine(this.Environment.WebRootPath, "img/") + "laptop.jpg"))
                        {
                            IsMainPicture = true
                        }
                    },
                    Price = 3000.0M,
                    DateOfPublication= DateTime.Now,
                    Location = "Wiry"

                },
                new Advertisement()
                {
                    User = new ApplicationUser("Adam"),
                    Category = new Category("Meble"),
                    Title = "Sprzedam laptopa",
                    Pictures = new List<Picture>
                    {
                        new Picture(System.IO.File.ReadAllBytes(Path.Combine(this.Environment.WebRootPath, "img/") + "laptop.jpg"))
                        {
                            IsMainPicture = true
                        }
                    },
                    Price = 3000.0M,
                    DateOfPublication= DateTime.Now,
                    Location = "Wiry"

                },
                new Advertisement()
                {
                    User = new ApplicationUser("Adam"),
                    Category = new Category("Meble"),
                    Title = "Sprzedam laptopa",
                    Pictures = new List<Picture>
                    {
                        new Picture(System.IO.File.ReadAllBytes(Path.Combine(this.Environment.WebRootPath, "img/") + "laptop.jpg"))
                        {
                            IsMainPicture = true
                        }
                    },
                    Price = 3000.0M,
                    DateOfPublication= DateTime.Now,
                    Location = "Wiry"

                },
                new Advertisement()
                {
                    User = new ApplicationUser("Adam"),
                    Category = new Category("Meble"),
                    Title = "Sprzedam laptopa",
                    Pictures = new List<Picture>
                    {
                        new Picture(System.IO.File.ReadAllBytes(Path.Combine(this.Environment.WebRootPath, "img/") + "laptop.jpg"))
                        {
                            IsMainPicture = true
                        }
                    },
                    Price = 3000.0M,
                    DateOfPublication= DateTime.Now,
                    Location = "Wiry"

                }
            };

            var filterCategories = new Collection<FilterCategory>
            {
                new FilterCategory(new Category("Moda")
                {
                    Id = 1
                })
                {
                    IsSelected = true
                },
                new FilterCategory(new Category("Motoryzacja")
                {
                    Id = 2
                })
                {
                    IsSelected = true
                },
                new FilterCategory(new Category("Zwierzęta")
                {
                    Id = 3
                })
                {
                    IsSelected = true
                },
                new FilterCategory(new Category("Dla dzieci")
                {
                    Id = 4
                })
                {
                    IsSelected = true
                },new FilterCategory(new Category("Moda")
                {
                    Id = 1
                })
                {
                    IsSelected = true
                },
                new FilterCategory(new Category("Motoryzacja")
                {
                    Id = 2
                })
                {
                    IsSelected = true
                },
                new FilterCategory(new Category("Zwierzęta")
                {
                    Id = 3
                })
                {
                    IsSelected = true
                },
                new FilterCategory(new Category("Dla dzieci")
                {
                    Id = 4
                })
                {
                    IsSelected = true
                },new FilterCategory(new Category("Moda")
                {
                    Id = 1
                })
                {
                    IsSelected = true
                },
                new FilterCategory(new Category("Motoryzacja")
                {
                    Id = 2
                })
                {
                    IsSelected = true
                },
                new FilterCategory(new Category("Zwierzęta")
                {
                    Id = 3
                })
                {
                    IsSelected = true
                },
                new FilterCategory(new Category("Dla dzieci")
                {
                    Id = 4
                })
                {
                    IsSelected = true
                },new FilterCategory(new Category("Moda")
                {
                    Id = 1
                })
                {
                    IsSelected = true
                },
                new FilterCategory(new Category("Motoryzacja")
                {
                    Id = 2
                })
                {
                    IsSelected = true
                },
                new FilterCategory(new Category("Zwierzęta")
                {
                    Id = 3
                })
                {
                    IsSelected = true
                },
                new FilterCategory(new Category("Dla dzieci")
                {
                    Id = 4
                })
                {
                    IsSelected = true
                },new FilterCategory(new Category("Moda")
                {
                    Id = 1
                })
                {
                    IsSelected = true
                },
                new FilterCategory(new Category("Motoryzacja")
                {
                    Id = 2
                })
                {
                    IsSelected = true
                },
                new FilterCategory(new Category("Zwierzęta")
                {
                    Id = 3
                })
                {
                    IsSelected = true
                },
                new FilterCategory(new Category("Dla dzieci")
                {
                    Id = 4
                })
                {
                    IsSelected = true
                },new FilterCategory(new Category("Moda")
                {
                    Id = 1
                })
                {
                    IsSelected = true
                },
                new FilterCategory(new Category("Motoryzacja")
                {
                    Id = 2
                })
                {
                    IsSelected = true
                },
                new FilterCategory(new Category("Zwierzęta")
                {
                    Id = 3
                })
                {
                    IsSelected = true
                },
                new FilterCategory(new Category("Dla dzieci")
                {
                    Id = 4
                })
                {
                    IsSelected = true
                }
            };



            var vm = new AdvertisementsViewModel(new FilterAdvertisements { Categories = filterCategories }, advertisements);

            return View(vm);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult AdvertisementsTable()
        {
            var advertisements = new List<Advertisement>
            {
                new Advertisement()
                {
                    User = new ApplicationUser("Adam"),
                    Category = new Category("Meble"),
                    Title = "Sprzedam laptopa Sprzedam laptopa Sprzedam laptopa Sprzedam laptopa Sprzedam laptopa Sprzedam laptopa Sprzedam laptopa Sprzedam laptopa Sprzedam laptopa Sprzedam laptopa Sprzedam laptopa Sprzedam laptopa Sprzedam laptopa ",
                    Pictures = new List<Picture>
                    {
                        new Picture(System.IO.File.ReadAllBytes(Path.Combine(this.Environment.WebRootPath, "img/") + "laptop.jpg"))
                        {
                            IsMainPicture = true
                        }
                    },
                    Price = 3000.0M,
                    DateOfPublication= DateTime.Now,
                    Location = "Wiry"

                },
                new Advertisement()
                {
                    User = new ApplicationUser("Adam"),
                    Category = new Category("Meble"),
                    Title = "Sprzedam laptopa",
                    Pictures = new List<Picture>
                    {
                        new Picture(System.IO.File.ReadAllBytes(Path.Combine(this.Environment.WebRootPath, "img/") + "laptop.jpg"))
                        {
                            IsMainPicture = true
                        }
                    },
                    Price = 3000.0M,
                    DateOfPublication= DateTime.Now,
                    Location = "Wiry"

                },
                new Advertisement()
                {
                    User = new ApplicationUser("Adam"),
                    Category = new Category("Meble"),
                    Title = "Sprzedam laptopa",
                    Pictures = new List<Picture>
                    {
                        new Picture(System.IO.File.ReadAllBytes(Path.Combine(this.Environment.WebRootPath, "img/") + "laptop.jpg"))
                        {
                            IsMainPicture = true
                        }
                    },
                    Price = 3000.0M,
                    DateOfPublication= DateTime.Now,
                    Location = "Wiry"

                },
                new Advertisement()
                {
                    User = new ApplicationUser("Adam"),
                    Category = new Category("Meble"),
                    Title = "Sprzedam laptopa",
                    Pictures = new List<Picture>
                    {
                        new Picture(System.IO.File.ReadAllBytes(Path.Combine(this.Environment.WebRootPath, "img/") + "laptop.jpg"))
                        {
                            IsMainPicture = true
                        }
                    },
                    Price = 3000.0M,
                    DateOfPublication= DateTime.Now,
                    Location = "Wiry"

                },
                new Advertisement()
                {
                    User = new ApplicationUser("Adam"),
                    Category = new Category("Meble"),
                    Title = "Sprzedam laptopa",
                    Pictures = new List<Picture>
                    {
                        new Picture(System.IO.File.ReadAllBytes(Path.Combine(this.Environment.WebRootPath, "img/") + "laptop.jpg"))
                        {
                            IsMainPicture = true
                        }
                    },
                    Price = 3000.0M,
                    DateOfPublication= DateTime.Now,
                    Location = "Wiry"

                }
            };

            return PartialView("_AdvertisementsTable", advertisements);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult AdvertisementsCards()
        {
            var advertisements = new List<Advertisement>
            {
                new Advertisement()
                {
                    User = new ApplicationUser("Adam"),
                    Category = new Category("Meble"),
                    Title = "Sprzedam laptopa Sprzedam laptopa Sprzedam laptopa Sprzedam laptopa Sprzedam laptopa Sprzedam laptopa",
                    Pictures = new List<Picture>
                    {
                        new Picture(System.IO.File.ReadAllBytes(Path.Combine(this.Environment.WebRootPath, "img/") + "laptop.jpg"))
                        {
                            IsMainPicture = true
                        }
                    },
                    Price = 3000.0M,
                    DateOfPublication= DateTime.Now,
                    Location = "Wiry"

                },
                new Advertisement()
                {
                    User = new ApplicationUser("Adam"),
                    Category = new Category("Meble"),
                    Title = "Sprzedam laptopa",
                    Pictures = new List<Picture>
                    {
                        new Picture(System.IO.File.ReadAllBytes(Path.Combine(this.Environment.WebRootPath, "img/") + "laptop.jpg"))
                        {
                            IsMainPicture = true
                        }
                    },
                    Price = 3000.0M,
                    DateOfPublication= DateTime.Now,
                    Location = "Wiry"

                },
                new Advertisement()
                {
                    User = new ApplicationUser("Adam"),
                    Category = new Category("Meble"),
                    Title = "Sprzedam laptopa",
                    Pictures = new List<Picture>
                    {
                        new Picture(System.IO.File.ReadAllBytes(Path.Combine(this.Environment.WebRootPath, "img/") + "laptop.jpg"))
                        {
                            IsMainPicture = true
                        }
                    },
                    Price = 3000.0M,
                    DateOfPublication= DateTime.Now,
                    Location = "Wiry"

                },
                new Advertisement()
                {
                    User = new ApplicationUser("Adam"),
                    Category = new Category("Meble"),
                    Title = "Sprzedam laptopa",
                    Pictures = new List<Picture>
                    {
                        new Picture(System.IO.File.ReadAllBytes(Path.Combine(this.Environment.WebRootPath, "img/") + "laptop.jpg"))
                        {
                            IsMainPicture = true
                        }
                    },
                    Price = 3000.0M,
                    DateOfPublication= DateTime.Now,
                    Location = "Wiry"

                },
                new Advertisement()
                {
                    User = new ApplicationUser("Adam"),
                    Category = new Category("Meble"),
                    Title = "Sprzedam laptopa",
                    Pictures = new List<Picture>
                    {
                        new Picture(System.IO.File.ReadAllBytes(Path.Combine(this.Environment.WebRootPath, "img/") + "laptop.jpg"))
                        {
                            IsMainPicture = true
                        }
                    },
                    Price = 3000.0M,
                    DateOfPublication= DateTime.Now,
                    Location = "Wiry"

                }
            };

            return PartialView("_AdvertisementsCards", advertisements);
        }


        [AllowAnonymous]
        public IActionResult ViewAdvertisement()
        {
            var advertisement = new Advertisement()
            {
                User = new ApplicationUser("Adam"),
                Category = new Category("Meble"),
                Description = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur?",
                Title = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua",
                Pictures = new List<Picture>
                    {
                        new Picture(System.IO.File.ReadAllBytes(Path.Combine(this.Environment.WebRootPath, "img/") + "laptop.jpg"))
                        {
                            IsMainPicture = true
                        },
                        new Picture(System.IO.File.ReadAllBytes(Path.Combine(this.Environment.WebRootPath, "img/") + "laptop.jpg"))
                        {
                            IsMainPicture = false
                        },
                        new Picture(System.IO.File.ReadAllBytes(Path.Combine(this.Environment.WebRootPath, "img/") + "laptop.jpg"))
                        {
                            IsMainPicture = false
                        },
                        new Picture(System.IO.File.ReadAllBytes(Path.Combine(this.Environment.WebRootPath, "img/") + "laptop.jpg"))
                        {
                            IsMainPicture = false
                        },
                        new Picture(System.IO.File.ReadAllBytes(Path.Combine(this.Environment.WebRootPath, "img/") + "laptop.jpg"))
                        {
                            IsMainPicture = false
                        },
                        new Picture(System.IO.File.ReadAllBytes(Path.Combine(this.Environment.WebRootPath, "img/") + "laptop.jpg"))
                        {
                            IsMainPicture = false
                        },
                        new Picture(System.IO.File.ReadAllBytes(Path.Combine(this.Environment.WebRootPath, "img/") + "laptop.jpg"))
                        {
                            IsMainPicture = false
                        },
                        new Picture(System.IO.File.ReadAllBytes(Path.Combine(this.Environment.WebRootPath, "img/") + "laptop.jpg"))
                        {
                            IsMainPicture = false
                        },
                        new Picture(System.IO.File.ReadAllBytes(Path.Combine(this.Environment.WebRootPath, "img/") + "laptop.jpg"))
                        {
                            IsMainPicture = false
                        },
                        new Picture(System.IO.File.ReadAllBytes(Path.Combine(this.Environment.WebRootPath, "img/") + "laptop.jpg"))
                        {
                            IsMainPicture = false
                        }
                    },
                Price = 3000.0M,
                DateOfPublication = DateTime.Now,
                Location = "Wiry"
            };

            return View(advertisement);
        }
    }
}
