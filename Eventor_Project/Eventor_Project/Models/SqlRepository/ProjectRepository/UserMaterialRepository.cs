using System.Linq;
using Eventor_Project.Models.ProjectModel.Relations;

namespace Eventor_Project.Models.SqlRepository
{
    public partial class SqlRepository
    {
        public IQueryable<UserMaterial> UserMaterials
        {
            get { return Db.UserMaterials; }
        }

        public bool CreateUserMaterial(UserMaterial instance)
        {
            if (instance.UserMaterialId != 0) return false;
            Db.UserMaterials.Add(instance);
            Db.SaveChanges();
            return true;
        }

        public bool UpdateUserMaterial(UserMaterial instance)
        {
            var cache = Db.UserMaterials.FirstOrDefault(p => p.UserMaterialId == instance.UserMaterialId);
            if (cache == null) return false;
            cache.Amount = instance.Amount;
            Db.SaveChanges();
            return true;
        }

        public bool DeleteUserMaterial(int userMaterialId)
        {
            var instance = Db.UserMaterials.FirstOrDefault(p => p.UserMaterialId == userMaterialId);
            if (instance != null)
            {
                Db.UserMaterials.Remove(instance);
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public UserMaterial ReadUserMaterial(int userMaterialId)
        {
            var instance = Db.UserMaterials.FirstOrDefault(p => p.UserMaterialId == userMaterialId);
            return instance;
        }
    }
}