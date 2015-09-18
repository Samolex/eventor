using Eventor_Project.Models.ProjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            if (instance.MaterialId == 0)
            {
                Db.Materials.Add(instance);
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool UpdateMaterial(Material instance)
        {
            Material cache = Db.Materials.Where(p => p.MaterialId == instance.MaterialId).FirstOrDefault();
            if (cache != null)
            {
                //TODO : Update fields for Material
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool DeleteMaterial(int MaterialId)
        {
            Material instance = Db.Materials.Where(p => p.MaterialId == MaterialId).FirstOrDefault();
            if (instance != null)
            {
                Db.Materials.Remove(instance);
                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public Material ReadMaterial(int MaterialId)
        {
            Material instance = Db.Materials.Where(p => p.MaterialId == MaterialId).FirstOrDefault();
            return instance;
        }
        
    }
}