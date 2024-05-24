using MediatR;
using ServerCQRS.Domain.Entities;

namespace ServerCQRS.Application.Members.Commands
{
    public class MemberCommandBase : IRequest<Member>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public bool? IsActive { get; set; }
    }
}
