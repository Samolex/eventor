using System.Linq;
using Eventor_Project.Models.ProjectModel;
using System;

namespace Eventor_Project.Models.SqlRepository
{
    public partial class SqlRepository
    {
        public IQueryable<Picture> Pictures
        {
            get { return Db.Pictures; }
        }

        public bool CreatePicture(Picture instance)
        {
            try
            {
                if (instance.PictureId == 0)
                {
                    Db.Pictures.Add(instance);
                    Db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdatePicture(Picture instance)
        {
            try
            {
                Picture Picture = Db.Pictures.Find(instance.PictureId);
                Type type = instance.GetType();

                foreach (var info in type.GetProperties())
                {
                    if (info.CanWrite)
                    {
                        var value = info.GetValue(instance);
                        if (value != null)
                        {
                            info.SetValue(Picture, value, null);
                        }
                    }
                }
                Db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeletePicture(int PictureId)
        {
            try
            {
                var instance = Db.Pictures.FirstOrDefault(p => p.PictureId == PictureId);
                if (instance == null) return false;
                Db.Pictures.Remove(instance);
                Db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Picture ReadPicture(int PictureId)
        {
            var instance = Db.Pictures.FirstOrDefault(p => p.PictureId == PictureId);
            return instance;
        }
    }
}