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
            try
            {
                if (instance.UserMaterialId != 0) return false;
                Db.UserMaterials.Add(instance);
                Db.SaveChanges();
                return true;
            }
            catch
            {
                return true;
            }
        }

        public bool UpdateUserMaterial(UserMaterial instance)
        {
            try
            {
                var userMaterial = Db.UserMaterials.Find(instance.UserMaterialId);
                var type = instance.GetType();
                foreach(var info in type.GetProperties())
                {
                    if(info.CanWrite)
                    {
                        var value = info.GetValue(instance);
                        if(value != null)
                        {
                            info.SetValue(userMaterial, value, null);
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

        public bool DeleteUserMaterial(int userMaterialId)
        {
            try
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
            catch
            {
                return false;
            }
        }

        public UserMaterial ReadUserMaterial(int userMaterialId)
        {
            var instance = Db.UserMaterials.FirstOrDefault(p => p.UserMaterialId == userMaterialId);
            return instance;
        }
    }
}