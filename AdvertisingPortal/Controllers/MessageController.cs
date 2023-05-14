using AdvertisingPortal.Core.Models.Domains;
using AdvertisingPortal.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using MyTasks.Persistence.Extensions;

namespace AdvertisingPortal.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Messages(string interlocutorId)
        {
            var userId = User.GetUserId();

            var users = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Id = userId,
                    UserName = "Maciej"
                },
                new ApplicationUser
                {
                    Id = interlocutorId,
                    UserName = "Adam"
                }
             };


            var messages = new List<Message>
            {
                new Message
                {
                    Sender = users[0],
                    SenderId= users[0].Id,
                    Receiver = users[1],
                    ReceiverId = users[1].Id,
                    Content = "Cześć Adam!"
                },
                new Message
                {
                    Sender = users[1],
                    SenderId= users[1].Id,
                    Receiver = users[0],
                    ReceiverId = users[0].Id,
                    Content = "Cześć Maciej!"
                },
                new Message
                {
                    Sender = users[0],
                    SenderId= users[0].Id,
                    Receiver = users[1],
                    ReceiverId = users[1].Id,
                    Content = "Co tam?"
                },
                new Message
                {
                    Sender = users[1],
                    SenderId= users[1].Id,
                    Receiver = users[0],
                    ReceiverId = users[0].Id,
                    Content = "Stara bida"
                }
            };



            var vm = new MessagesViewModel(messages, users[0], users[1]);

            return View(vm);
        }

        [HttpPost]
        public IActionResult SendMessage(Message message)
        {
            if (!ModelState.IsValid)
                return View(message.ReceiverId);

            var userId = User.GetUserId();

            var users = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Id = userId,
                    UserName = "Maciej"
                },
                new ApplicationUser
                {
                    Id = message.ReceiverId,
                    UserName = "Adam"
                }
             };

            message.SendTime = DateTime.Now;
            message.Sender = users[0];
            message.Receiver = users[1];
            message.Sender.Id = users[0].Id;
            message.ReceiverId = users[1].Id;

            var messages = new List<Message>
            {
                new Message
                {
                    Sender = users[0],
                    SenderId= users[0].Id,
                    Receiver = users[1],
                    ReceiverId = users[1].Id,
                    Content = "Cześć Adam!"
                },
                new Message
                {
                    Sender = users[1],
                    SenderId= users[1].Id,
                    Receiver = users[0],
                    ReceiverId = users[0].Id,
                    Content = "Cześć Maciej!"
                },
                new Message
                {
                    Sender = users[0],
                    SenderId= users[0].Id,
                    Receiver = users[1],
                    ReceiverId = users[1].Id,
                    Content = "Co tam?"
                },
                new Message
                {
                    Sender = users[1],
                    SenderId= users[1].Id,
                    Receiver = users[0],
                    ReceiverId = users[0].Id,
                    Content = "Stara bida"
                },
                message
            };

            var vm = new MessagesViewModel(messages, users[0], users[1]);


            return PartialView("_MessagesHistory", vm);
        }
    }
}
