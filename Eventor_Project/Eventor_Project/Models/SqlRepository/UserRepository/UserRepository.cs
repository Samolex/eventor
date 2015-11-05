using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Eventor_Project.Models.ProjectModel;
using Eventor_Project.Models.ProjectModel.Relations;
using Eventor_Project.Models.User;

namespace Eventor_Project.Models.SqlRepository
{
    public partial class SqlRepository
    {

        public User.User GetUser(string email)
        {
            var user = Db.Users.FirstOrDefault(p => string.Compare(p.Email, email, true) == 0);
            return user;
        }

        public User.User GetUser(int id)
        {
            return Db.Users.FirstOrDefault(p => p.UserId == id);
        }

        public User.User GetUserId(string data)
        {
            return Db.Users.FirstOrDefault(u => u.Email == data);
        }

        public User.User Login(string email, string password)
        {
            return Db.Users.FirstOrDefault(p => string.Compare(p.Email, email, true) == 0 && p.Password == password);
        }

        public IQueryable<User.User> Users
        {
            get
            {
                return Db.Users;
            }
        }

        public bool CreateUser(User.User instance)
        {
            instance.Birthdate = new DateTime(1950, 1, 3);
            if (instance.UserId == 0)
            {
                Db.Users.Add(instance);
                Db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateUser(User.User instance)
        {
            Models.User.User dbUser = GetUser(instance.UserId);
            if (dbUser != null)
            {
                var a = this.MemberwiseClone();
                Type t = instance.GetType();
                foreach (PropertyInfo info in t.GetProperties())
                {
                    if (info.CanWrite)
                    {
                        var value = info.GetValue(instance);
                        if (value != null)
                            info.SetValue(dbUser, value, null);
                    }
                }

                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool DeleteUser(int UserId)
        {
            User.User instance = Db.Users.FirstOrDefault(p => p.UserId == UserId);
            if (instance != null)
            {
                Db.Users.Remove(instance);
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public User.User ReadUser(int UserId)
        {
            User.User instance = Db.Users.FirstOrDefault(p => p.UserId == UserId);
            return instance;
        }
        
    }
}
