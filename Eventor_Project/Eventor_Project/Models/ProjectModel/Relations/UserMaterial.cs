namespace Eventor_Project.Models.ProjectModel.Relations
{
    public class UserMaterial
    {
        public int UserMaterialId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int MaterialId { get; set; }
        public virtual Material Material { get; set; }
        public int Amount { get; set; }
    }
}