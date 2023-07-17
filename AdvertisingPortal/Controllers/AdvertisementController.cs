using AdvertisingPortal.Core.Models;
using AdvertisingPortal.Core.Models.Domains;
using AdvertisingPortal.Core.Models.Services;
using AdvertisingPortal.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AdvertisingPortal.Persistence.Extensions;
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
            var userId = User.GetUserId();


            var vm = new ViewAdvertisementViewModel(advertisement, 
                                                    userId != null && advertisement.UserId != userId ? new Message { SenderId = userId, 
                                                                                                                     ReceiverId = advertisement.UserId,
                                                                                                                     AdvertisementId = advertisement.Id, 
                                                    } 
                                                                                                     : null);

            return View(vm);
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

            ViewBag.UserId = userId;

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

            ViewBag.UserId = userId;

            return PartialView("_AdvertisementsTable", advertisements);
        }

        [HttpPost]
        public IActionResult UserAdvertisementsCards()
        {
            var userId = User.GetUserId();

            var advertisements = _advertisementService.GetAdvertisements(userId);

            ViewBag.UserId = userId;

            return PartialView("_AdvertisementsCards", advertisements);
        }



        public IActionResult CreateAdvertisement(int id = 0)
        {
            var userId = User.GetUserId();


            var vm = CreateCreateAdvertisementViewModel(userId, id);


            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAdvertisement(Advertisement advertisement, IEnumerable<IFormFile> images, int[] deletedPictures, int? mainPicture)
        {
            var userId = User.GetUserId();

            

            advertisement.UserId = userId;


            if (!ModelState.IsValid)
            {
                var vm = CreateCreateAdvertisementViewModel(userId, advertisement.Id);
                return View(nameof(CreateAdvertisement), vm);
            }          


            if (advertisement.Id == 0)
                _advertisementService.AddAdvertisement(advertisement, images, mainPicture);
            else
                _advertisementService.UpdateAdvertisement(advertisement, images, deletedPictures, mainPicture);


            return RedirectToAction(nameof(UserAdvertisements));
        }

        [HttpPost]
        public IActionResult DeleteAdvertisement(int id)
        {          
            try
            {
                var userId = User.GetUserId();
                _advertisementService.DeleteAdvertisement(id, userId);
            }
            catch (Exception ex)
            {
                //logowanie
                return Json(new { success = false, message = ex.Message });
            }
            return Json(new { success = true });
        }


        private CreateAdvertisementViewModel CreateCreateAdvertisementViewModel(string userId, int advertisementId)
        {
            return new CreateAdvertisementViewModel(advertisementId == 0 ? new Advertisement { UserId = userId } : _advertisementService.GetAdvertisement(userId, advertisementId),
                                                      _categoryService.GetCategories(),
                                                      advertisementId == 0 ? "Dodawanie ogłoszenia" : "Edycja ogłoszenia");
        }

        
    }
}
