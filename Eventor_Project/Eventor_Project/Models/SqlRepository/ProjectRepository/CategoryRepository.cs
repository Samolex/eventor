using System.Linq;
using Eventor_Project.Models.ProjectModel;

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
            if (instance.CategoryId == 0)
            {
                Db.Categories.Add(instance);
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool UpdateCategory(Category instance)
        {
            var cache = Db.Categories.FirstOrDefault(p => p.CategoryId == instance.CategoryId);
            if (cache == null) return false;
            cache.Name = instance.Name;
            Db.SaveChanges();
            return true;
        }

        public bool DeleteCategory(int categoryId)
        {
            var instance = Db.Categories.FirstOrDefault(p => p.CategoryId == categoryId);
            if (instance == null) return false;
            Db.Categories.Remove(instance);
            Db.SaveChanges();
            return true;
        }

        public Category ReadCategory(int categoryId)
        {
            var instance = Db.Categories.FirstOrDefault(p => p.CategoryId == categoryId);
            return instance;
        }
    }
}