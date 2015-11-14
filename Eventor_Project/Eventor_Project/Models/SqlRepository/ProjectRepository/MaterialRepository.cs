using System.Linq;
using Eventor_Project.Models.ProjectModel;
using System;
using System.Collections.Generic;

namespace Eventor_Project.Models.SqlRepository
{
    public partial class SqlRepository
    {
        public IQueryable<Material> Materials
        {
            get { return Db.Materials; }
        }

        public bool CreateMaterial(Material instance)
        {
            try
            {
                if (instance.MaterialId != 0) return false;
                Db.Materials.Add(instance);
                Db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateMaterial(Material instance)
        {
            try
            {
                Material material = Db.Materials.Find(instance.MaterialId);
                Type type = instance.GetType();

                foreach (var info in type.GetProperties())
                {
                    if (info.CanWrite)
                    {
                        var value = info.GetValue(instance);
                        if (value != null)
                        {
                            info.SetValue(material, value, null);
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

        public bool DeleteMaterial(int materialId)
        {
            try
            {
                var instance = Db.Materials.FirstOrDefault(p => p.MaterialId == materialId);
                if (instance == null) return false;
                Db.Materials.Remove(instance);
                Db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Material ReadMaterial(int materialId)
        {
            var instance = Db.Materials.FirstOrDefault(p => p.MaterialId == materialId);
            return instance;
        }

        public void SaveMaterials(List<Material> materials)
        {
            try
            {
                var projectId = materials.FirstOrDefault().ProjectId;
                var project = ReadProject(projectId);
                Type type = project.GetType();
                var info = type.GetProperty("Inventory");
                if (info.CanWrite)
                {
                    info.SetValue(project,null);
                    info.SetValue(project, materials);
                }
                Db.SaveChanges();
            }
            catch
            {

            }
        }
    }
}