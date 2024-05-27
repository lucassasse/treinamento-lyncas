using ServerCQRS.Domain.Validation;
using System.Text.Json.Serialization;

namespace ServerCQRS.Domain.Entities
{
    public sealed class Customer : Entity
    {
        public string? FullName { get; private set; }
        public string? Email { get; private set; }
        public string? Telephone { get; private set; }
        public string? Cpf { get; private set; }
        public bool? SoftDeleted { get; private set; }
        public DateTime? DeletedAt { get; private set; }
        //[JsonIgnore]
        //public virtual List<Sale> Sales { get; set; }

        public Customer(string fullName, string email, string telephone, string cpf, bool softDeleted, DateTime deletedAt)
        {
            ValidateDomain(fullName, email, telephone, cpf, softDeleted, deletedAt);
        }

        public Customer() { }

        [JsonConstructor]
        public Customer(int id, string fullName, string email, string telephone, string cpf, bool softDeleted, DateTime deletedAt)
        {
            DomainValidation.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(fullName, email, telephone, cpf, softDeleted, deletedAt);
        }

        public void Update(string fullName, string email, string telephone, string cpf, bool softDeleted, DateTime deletedAt)
        {
            ValidateDomain(fullName, email, telephone, cpf, softDeleted, deletedAt);
        }

        private void ValidateDomain(string fullName, string email, string telephone, string cpf, bool softDeleted, DateTime deletedAt)
        {
            DomainValidation.When(string.IsNullOrEmpty(fullName),
                "Invalid name. Fullname is required.");

            DomainValidation.When(fullName.Length < 5,
                "Invalid name, too short, minimum 5 characters.");

            DomainValidation.When(string.IsNullOrEmpty(email),
                "Invalid email. Email is required.");

            DomainValidation.When(email?.Length < 6,
                "Invalid email, too short, minimum 6 characters.");

            DomainValidation.When(string.IsNullOrEmpty(telephone),
                "Invalid telephone. Telephone is required.");

            DomainValidation.When(telephone?.Length < 10,
                "Invalid telephone, too short, minimum 10 characters.");

            DomainValidation.When(string.IsNullOrEmpty(cpf),
                "Invalid cpf. Cpf is required.");

            // Possibilidade de adicionar mais várias validações

            FullName = fullName;
            Email = email;
            Telephone = telephone;
            Cpf = cpf;
            SoftDeleted = softDeleted;
            DeletedAt = deletedAt;
        }
    }
}
