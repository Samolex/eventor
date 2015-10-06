using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventor_Project.Models.SqlRepository
{
    public partial class SqlRepository
    {

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
            User.User cache = Db.Users.Where(p => p.UserId == instance.UserId).FirstOrDefault();
            if (cache != null)
            {
                cache.ContactEmail = instance.ContactEmail;
                cache.Email = instance.Email;
                cache.Name = instance.Name;
                cache.Nickname = instance.Nickname;
                cache.Patronymic = instance.Patronymic;
                cache.PhoneNumber = instance.PhoneNumber;
                cache.PlaceOfLiving = instance.PlaceOfLiving;
                cache.PlaceOfStudy = instance.PlaceOfStudy;
                cache.Sex = instance.Sex;
                cache.Surname = instance.Surname;
                cache.Password = instance.Password;

                cache.Benefits = instance.Benefits;
                cache.Roles = instance.Roles;

                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool DeleteUser(int UserId)
        {
            User.User instance = Db.Users.Where(p => p.UserId == UserId).FirstOrDefault();
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
            User.User instance = Db.Users.Where(p => p.UserId == UserId).FirstOrDefault();
            return instance;
        }
        
    }
}
