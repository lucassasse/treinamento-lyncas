using MediatR;
using ServerCQRS.Domain.Entities;
using System.Text.Json.Serialization;

namespace ServerCQRS.Application.Customers.Commands
{
    public abstract class CustomerCommandBase : IRequest<Customer>
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Telephone { get; set; }
        public string? Cpf { get; set; }
        public bool SoftDeleted { get; set; }
        public DateTime DeletedAt { get; set; }
        [JsonIgnore]
        public List<Sale>? Sale { get; set; }
    }
}
