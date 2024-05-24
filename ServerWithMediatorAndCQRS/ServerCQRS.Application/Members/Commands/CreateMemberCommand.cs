using MediatR;
using ServerCQRS.Domain.Abstractions;
using ServerCQRS.Domain.Entities;

namespace ServerCQRS.Application.Members.Commands
{
    public sealed class CreateMemberCommand : IRequest<Member>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public bool? IsActive { get; set; }
    }

    public class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, Member>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateMemberCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Member> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {
            var newMember = new Member(request.FirstName, request.LastName, request.Gender, request.Email, request.IsActive);

            await _unitOfWork.MemberRepository.AddMember(newMember);
            await _unitOfWork.CommitAsync();

            return newMember;
        }
    }
}
