using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eventor_Project.Models.User;

namespace Eventor_Project.Models.SqlRepository
{
    public partial class SqlRepository
    {


        public IQueryable<User.Message> Messages
        {
            get
            {
                return Db.Messages;
            }
        }

        public bool CreateMessage(User.Message instance)
        {
            if (instance.MessageId == 0)
            {
                Db.Messages.Add(instance);
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool UpdateMessage(User.Message instance)
        {
            User.Message cache = Db.Messages.FirstOrDefault(p => p.MessageId == instance.MessageId);
            if (cache != null)
            {
                cache.Text = instance.Text;
                cache.Topic = instance.Topic;
                cache.ReceiverId = instance.ReceiverId;
                cache.SenderId = instance.SenderId;
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool DeleteMessage(int MessageId)
        {
            User.Message instance = Db.Messages.FirstOrDefault(p => p.MessageId == MessageId);
            if (instance != null)
            {
                Db.Messages.Remove(instance);
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public User.Message ReadMessage(int MessageId)
        {
            User.Message instance = Db.Messages.FirstOrDefault(p => p.MessageId == MessageId);
            return instance;
        }

    }
}