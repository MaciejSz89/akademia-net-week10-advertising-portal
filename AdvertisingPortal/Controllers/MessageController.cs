using AdvertisingPortal.Core.Models.Domains;
using AdvertisingPortal.Core.Models.Services;
using AdvertisingPortal.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using AdvertisingPortal.Persistence.Extensions;

namespace AdvertisingPortal.Controllers
{
    public class MessageController : Controller
    {
        public IMessageService MessageService { get; set; }

        public MessageController(IMessageService messageService)
        {
            MessageService = messageService;
        }


        public IActionResult Conversation(string interlocutorId, int advertisementId)
        {
            var userId = User.GetUserId();

            var vm = new ConversationViewModel
            {
                Message = new Message
                {
                    SenderId = userId,
                    AdvertisementId = advertisementId,
                    ReceiverId = interlocutorId
                },
                Conversation = MessageService.GetConversation(userId, interlocutorId, advertisementId)
            };

            return View(vm);
        }

        public IActionResult Conversations()
        {
            var userId = User.GetUserId();

            var vm = new ConversationsViewModel
            {
                UserId = userId,
                Conversations = MessageService.GetConversations(userId)
            };

            return View(vm);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SendAdvertisementMessage(Message message)
        {
            try
            {
                MessageService.SendMessage(message);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }

            return Json(new { success = true });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SendConversationMessage(Message message)
        {
            var userId = User.GetUserId();

            if (message.ReceiverId==null)
                return RedirectToAction(nameof(Conversations));

            try
            {
                MessageService.SendMessage(message);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }

            

            return PartialView("_ConversationHistory", MessageService.GetConversation(userId, message.ReceiverId, message.AdvertisementId));
        }
    }
}
