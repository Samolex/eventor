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
        public ActionResult NewMessage(int recId = -1, int prevMessageId = -1)
        {
            var message = new MessageView();
            message.ReceiverId = recId;
            message.ReceiverNick = Repository.GetUser(recId).Nickname;
            message.SenderId = CurrentUser.UserId;
            message.SenderNick = CurrentUser.Nickname;
            message.PrevMessage = ((prevMessageId > 0) ? Repository.ReadMessage(prevMessageId) : null);
            message.Topic = ((message.PrevMessage != null) ? "Re: " + message.PrevMessage.Topic : null);
            return View(message);
        }

        [Authorize]
        [HttpPost]
        public ActionResult SendMessage(MessageView messageView)
        {
            if (ModelState.IsValid)
            {
                var message = (Message)ModelMapper.Map(messageView, typeof(MessageView), typeof(Message));
                Repository.CreateMessage(message);
                return RedirectToAction("Index");
            }
            return View("NewMessage");
        }

    }
}
