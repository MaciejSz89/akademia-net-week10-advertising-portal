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
        private IPictureService _pictureService;

        public AdvertisementController(IWebHostEnvironment _environment, IAdvertisementService advertisementService, ICategoryService categoryService, IPictureService pictureService)
        {
            Environment = _environment;
            _advertisementService = advertisementService;
            _categoryService = categoryService;
            _pictureService = pictureService;
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
            var categories = _categoryService.GetCategories();
            var filterAdvertisement = new FilterAdvertisements();

            var vm = new AdvertisementsViewModel(filterAdvertisement, SortAdvertisements.ByDateOfPublicationDescending, advertisements, categories);

            return View(vm);
        }

        public IActionResult UserAdvertisements()
        {
            var userId = User.GetUserId();

            var advertisements = _advertisementService.GetAdvertisements(userId);

            return View(advertisements);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult AdvertisementsTable(FilterAdvertisements filterAdvertisements, SortAdvertisements sortAdvertisements)
        {
            var getAdvertisementParams = new GetAdvertisementsParams(filterAdvertisements,
                                                                     sortAdvertisements);

            var advertisements = _advertisementService.GetAdvertisements(getAdvertisementParams);

            return PartialView("_AdvertisementsTable", advertisements);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult AdvertisementsCards(FilterAdvertisements filterAdvertisements, SortAdvertisements sortAdvertisements)
        {
            var getAdvertisementParams = new GetAdvertisementsParams(filterAdvertisements, sortAdvertisements);

            var advertisements = _advertisementService.GetAdvertisements(getAdvertisementParams);

            return PartialView("_AdvertisementsCards", advertisements);
        }


        [HttpPost]
        public IActionResult UserAdvertisementsTable()
        {
            var userId = User.GetUserId();

            var advertisements = _advertisementService.GetAdvertisements(userId);

            return PartialView("_AdvertisementsTable", advertisements);
        }

        [HttpPost]
        public IActionResult UserAdvertisementsCards()
        {
            var userId = User.GetUserId();

            var advertisements = _advertisementService.GetAdvertisements(userId);

            return PartialView("_AdvertisementsCards", advertisements);
        }



        public IActionResult CreateAdvertisement(int id = 0)
        {
            var userId = User.GetUserId();


            var vm = CreateCreateAdvertisementViewModel(userId, id);


            return View(vm);
        }

        [HttpPost]
        public IActionResult CreateAdvertisement(Advertisement advertisement, IEnumerable<IFormFile> images, int[] deletedPictures)
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

            if (images != null && images.Any())
            {
                if (advertisement.Id == 0)
                    _advertisementService.AddPicturesToAdvertisement(advertisement, images);
                else
                    _pictureService.AddPictures(userId, advertisement.Id, images);
            }


            if (deletedPictures != null && deletedPictures.Any())
                _pictureService.DeletePictures(userId, deletedPictures);



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
