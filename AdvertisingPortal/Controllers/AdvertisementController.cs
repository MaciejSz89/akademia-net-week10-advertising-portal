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
                new Advertisement("jndafkjfd0")
                {
                    User = new ApplicationUser("Adam"),
                    Category = new Category("Meble"),
                    Title = "Sprzedam laptopa Sprzedam laptopa Sprzedam laptopa Sprzedam laptopa Sprzedam laptopa Sprzedam laptopa Sprzedam laptopa Sprzedam laptopa Sprzedam laptopa Sprzedam laptopa Sprzedam laptopa Sprzedam laptopa Sprzedam laptopa ",
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

            return PartialView("_AdvertisementsTable", advertisements);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult AdvertisementsCards()
        {
            var advertisements = new List<Advertisement>
            {
                new Advertisement("jndafkjfd0")
                {
                    User = new ApplicationUser("Adam"),
                    Category = new Category("Meble"),
                    Title = "Sprzedam laptopa Sprzedam laptopa Sprzedam laptopa Sprzedam laptopa Sprzedam laptopa Sprzedam laptopa",
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

            return PartialView("_AdvertisementsCards", advertisements);
        }


        [AllowAnonymous]
        public IActionResult ViewAdvertisement()
        {
            var advertisement = new Advertisement("jfsdkjfn")
            {
                User = new ApplicationUser("Adam"),
                Category = new Category("Meble"),
                Title = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua",
                Pictures = new List<Picture>
                    {
                        new Picture(System.IO.File.ReadAllBytes(Path.Combine(this.Environment.WebRootPath, "img/") + "laptop.jpg"), "jndafkjfd0")
                        {
                            IsMainPicture = true
                        },
                        new Picture(System.IO.File.ReadAllBytes(Path.Combine(this.Environment.WebRootPath, "img/") + "laptop.jpg"), "jndafkjfd0")
                        {
                            IsMainPicture = false
                        },
                        new Picture(System.IO.File.ReadAllBytes(Path.Combine(this.Environment.WebRootPath, "img/") + "laptop.jpg"), "jndafkjfd0")
                        {
                            IsMainPicture = false
                        },
                        new Picture(System.IO.File.ReadAllBytes(Path.Combine(this.Environment.WebRootPath, "img/") + "laptop.jpg"), "jndafkjfd0")
                        {
                            IsMainPicture = false
                        },
                        new Picture(System.IO.File.ReadAllBytes(Path.Combine(this.Environment.WebRootPath, "img/") + "laptop.jpg"), "jndafkjfd0")
                        {
                            IsMainPicture = false
                        },
                        new Picture(System.IO.File.ReadAllBytes(Path.Combine(this.Environment.WebRootPath, "img/") + "laptop.jpg"), "jndafkjfd0")
                        {
                            IsMainPicture = false
                        },
                        new Picture(System.IO.File.ReadAllBytes(Path.Combine(this.Environment.WebRootPath, "img/") + "laptop.jpg"), "jndafkjfd0")
                        {
                            IsMainPicture = false
                        },
                        new Picture(System.IO.File.ReadAllBytes(Path.Combine(this.Environment.WebRootPath, "img/") + "laptop.jpg"), "jndafkjfd0")
                        {
                            IsMainPicture = false
                        },
                        new Picture(System.IO.File.ReadAllBytes(Path.Combine(this.Environment.WebRootPath, "img/") + "laptop.jpg"), "jndafkjfd0")
                        {
                            IsMainPicture = false
                        },
                        new Picture(System.IO.File.ReadAllBytes(Path.Combine(this.Environment.WebRootPath, "img/") + "laptop.jpg"), "jndafkjfd0")
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
