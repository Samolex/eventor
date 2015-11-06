using System.Linq;
using Eventor_Project.Models.ProjectModel;
using System;

namespace Eventor_Project.Models.SqlRepository
{
    public partial class SqlRepository
    {
        public IQueryable<Category> Categories
        {
            get { return Db.Categories; }
        }

        public bool CreateCategory(Category instance)
        {
            try
            {
                if (instance.CategoryId == 0)
                {
                    Db.Categories.Add(instance);
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

        public bool UpdateCategory(Category instance)
        {
            try
            {
                Category category = Db.Categories.Find(instance.CategoryId);
                Type type = instance.GetType();

                foreach(var info in type.GetProperties())
                {
                    if(info.CanWrite)
                    {
                        var value = info.GetValue(instance);
                        if(value != null)
                        {
                            info.SetValue(category, value, null);
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

        public bool DeleteCategory(int categoryId)
        {
            try
            {
                var instance = Db.Categories.FirstOrDefault(p => p.CategoryId == categoryId);
                if (instance == null) return false;
                Db.Categories.Remove(instance);
                Db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Category ReadCategory(int categoryId)
        {
            var instance = Db.Categories.FirstOrDefault(p => p.CategoryId == categoryId);
            return instance;
        }
    }
}