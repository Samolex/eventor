using Eventor_Project.Models.ProjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventor_Project.Models.SqlRepository
{
    public partial class SqlRepository
    {


        public IQueryable<Category> Categories
        {
            get
            {
                return Db.Categories;
            }
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
            Category cache = Db.Categories.Where(p => p.CategoryId == instance.CategoryId).FirstOrDefault();
            if (cache != null)
            {
                //TODO : Update fields for Category
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool DeleteCategory(int CategoryId)
        {
            Category instance = Db.Categories.Where(p => p.CategoryId == CategoryId).FirstOrDefault();
            if (instance != null)
            {
                Db.Categories.Remove(instance);
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public Category ReadCategory(int CategoryId)
        {
            Category instance = Db.Categories.Where(p => p.CategoryId == CategoryId).FirstOrDefault();
            return instance;
        }
        
    }
}