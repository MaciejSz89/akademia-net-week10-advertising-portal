using AdvertisingPortal.Core.Models;
using AdvertisingPortal.Core.Models.Domains;
using AdvertisingPortal.Core.Models.Services;
using AdvertisingPortal.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTasks.Persistence.Extensions;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Security.Claims;
using IWebHostEnvironment = Microsoft.AspNetCore.Hosting.IWebHostEnvironment;

namespace AdvertisingPortal.Controllers
{

    [Authorize]
    public class AdvertisementController : Controller
    {
        private IWebHostEnvironment Environment;

        private IAdvertisementService _advertisementService;
        private ICategoryService _categoryService;

        public AdvertisementController(IWebHostEnvironment _environment, IAdvertisementService advertisementService, ICategoryService categoryService)
        {
            Environment = _environment;
            _advertisementService = advertisementService;
            _categoryService = categoryService;
        }

        [AllowAnonymous]
        public IActionResult ViewAdvertisement(int id)
        {
            var advertisement = _advertisementService.GetAdvertisement(id);

            return View(advertisement);
        }

        [AllowAnonymous]
        public IActionResult Advertisements()
        {


            var advertisements = _advertisementService.GetAdvertisements();

            
            var vm = new AdvertisementsViewModel(new FilterAdvertisements(_categoryService.GetCategories()), advertisements);

            return View(vm);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult AdvertisementsTable()
        {
            var advertisements = _advertisementService.GetAdvertisements();

            return PartialView("_AdvertisementsTable", advertisements);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult AdvertisementsCards()
        {
            var advertisements = _advertisementService.GetAdvertisements();

            return PartialView("_AdvertisementsCards", advertisements);
        }



        public IActionResult CreateAdvertisement(int id = 0)
        {
            var userId = User.GetUserId();


            var vm = CreateCreateAdvertisementViewModel(userId, id);


            return View(vm);
        }

        [HttpPost]
        public IActionResult CreateAdvertisement(Advertisement advertisement, IEnumerable<IFormFile> images)
        {
            var userId = User.GetUserId();

            if (advertisement.Id == 0)
            {
                advertisement.DateOfPublication = DateTime.Now;
            }

            advertisement.UserId = userId;


            if (!ModelState.IsValid)
            {
                var vm = CreateCreateAdvertisementViewModel(userId, advertisement.Id);
                return View(nameof(CreateAdvertisement), vm);
            }



            foreach (var image in images)
            {
                using var stream = new MemoryStream();
                image.CopyTo(stream);
                var picture = new Picture(stream.ToArray());
                picture.FileName = image.FileName;
                picture.UserId = userId;
                advertisement.Pictures.Add(picture);
            }

            if (advertisement.Id == 0)
                _advertisementService.AddAdvertisement(advertisement);
            else
                _advertisementService.UpdateAdvertisement(advertisement);


            return RedirectToAction(nameof(Advertisements));
        }


        private CreateAdvertisementViewModel CreateCreateAdvertisementViewModel(string userId, int advertisementId)
        {
            return new CreateAdvertisementViewModel(advertisementId == 0 ? new Advertisement { UserId = userId } : _advertisementService.GetAdvertisement(userId, advertisementId),
                                                      _categoryService.GetCategories(),
                                                      advertisementId == 0 ? "Dodawanie ogłoszenia" : "Edycja ogłoszenia");
        }
    }
}
