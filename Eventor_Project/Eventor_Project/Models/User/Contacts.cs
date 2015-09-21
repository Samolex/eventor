namespace Eventor_Project.Models
{
    public class Contacts
    {
        public int ContactsId { get; set; }
        public string ContactEmail { get; set; }
        public string PhoneNumber { get; set; }


        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}