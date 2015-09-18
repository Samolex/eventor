using Eventor_Project.Models.ProjectModel.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventor_Project.Models.SqlRepository
{
    public partial class SqlRepository
    {


        public IQueryable<UserMaterial> UserMaterials
        {
            get
            {
                return Db.UserMaterials;
            }
        }

        public bool CreateUserMaterial(UserMaterial instance)
        {
            if (instance.UserMaterialId == 0)
            {
                Db.UserMaterials.Add(instance);
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool UpdateUserMaterial(UserMaterial instance)
        {
            UserMaterial cache = Db.UserMaterials.Where(p => p.UserMaterialId == instance.UserMaterialId).FirstOrDefault();
            if (cache != null)
            {
                //TODO : Update fields for UserMaterial
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool DeleteUserMaterial(int UserMaterialId)
        {
            UserMaterial instance = Db.UserMaterials.Where(p => p.UserMaterialId == UserMaterialId).FirstOrDefault();
            if (instance != null)
            {
                Db.UserMaterials.Remove(instance);
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public UserMaterial ReadUserMaterial(int UserMaterialId)
        {
            UserMaterial instance = Db.UserMaterials.Where(p => p.UserMaterialId == UserMaterialId).FirstOrDefault();
            return instance;
        }
        
    }
}