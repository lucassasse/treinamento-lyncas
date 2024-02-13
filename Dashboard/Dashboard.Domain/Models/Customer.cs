namespace Domain.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Cpf { get; set; }
        public bool SoftDeleted { get; set; }
        public DateTime DeletedAt { get; set; }

        public virtual IList<Sale> Sales { get; set; }
    }
}
