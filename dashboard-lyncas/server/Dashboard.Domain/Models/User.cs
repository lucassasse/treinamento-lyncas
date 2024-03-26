namespace Dashboard.Domain.Models
{
    public class User : BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public byte[] HashPassword { get; set; }
        public byte[] SaltPassword { get; set; }
        public DateTime TokenDateCreation { get; set; } = DateTime.Now;
    }
}
