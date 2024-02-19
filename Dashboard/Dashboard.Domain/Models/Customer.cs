using System.Text.Json.Serialization;

namespace Dashboard.Domain.Models
{
    public class Customer : BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Cpf { get; set; }
        public bool SoftDeleted { get; set; }
        public DateTime DeletedAt { get; set; }

        [JsonIgnore]
        public virtual List<Sale> Sales { get; set; }
    }
}
