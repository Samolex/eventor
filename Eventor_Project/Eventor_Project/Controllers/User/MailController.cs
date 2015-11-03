using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Eventor_Project.Models;
using Eventor_Project.Models.ViewModels;
using Eventor_Project.Models.User;
namespace Eventor_Project.Controllers.User
{
    public class MailController : BaseController
    {
        private readonly CurrentContext db = new CurrentContext();
        //
        // GET: /Mail/

        [Authorize]
        public ActionResult Index()
        {
            return View(db.Messages.Where(x => x.SenderId == CurrentUser.UserId || x.ReceiverId == CurrentUser.UserId));
        }

        [Authorize]
        [HttpPost]
        public ActionResult NewMessage(MessageView messageView)
        {
            if (ModelState.IsValid)
            {
                var message = (Message)ModelMapper.Map(messageView, typeof(MessageView), typeof(Message));
                Repository.CreateMessage(message);
                return RedirectToAction("Index");
            }
            return View(messageView);
        }

        [Authorize]
        [HttpGet, HttpPost]
        public ActionResult NewMessage(int receiverId)
        {
            var message = new MessageView();
            message.ReceiverId = receiverId;
            message.ReceiverNick = Repository.GetUser(receiverId).Nickname;
            message.SenderId = CurrentUser.UserId;
            return View(message);
        }

    }
}
