namespace Eventor_Project.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}