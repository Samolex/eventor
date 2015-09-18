using Eventor_Project.Models.ProjectModel;
using System.Linq;

namespace Eventor_Project.Models.SqlRepository
{
    public partial class SqlRepository
    {

        public IQueryable<Material> Materials
        {
            get
            {
                return Db.Materials;
            }
        }

        public bool CreateMaterial(Material instance)
        {
            if (instance.MaterialId != 0) return false;
            Db.Materials.Add(instance);
            Db.SaveChanges();
            return true;
        }

        public bool UpdateMaterial(Material instance)
        {
            var cache = Db.Materials.FirstOrDefault(p => p.MaterialId == instance.MaterialId);
            if (cache == null) return false;
            cache.RequiredAmount = instance.RequiredAmount;
            cache.Title = instance.Title;
            Db.SaveChanges();
            return true;
        }

        public bool DeleteMaterial(int materialId)
        {
            var instance = Db.Materials.FirstOrDefault(p => p.MaterialId == materialId);
            if (instance == null) return false;
            Db.Materials.Remove(instance);
            Db.SaveChanges();
            return true;
        }

        public Material ReadMaterial(int materialId)
        {
            var instance = Db.Materials.FirstOrDefault(p => p.MaterialId == materialId);
            return instance;
        }
        
    }
}