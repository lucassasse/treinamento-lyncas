﻿using MediatR;
using ServerCQRS.Domain.Abstractions;
using ServerCQRS.Domain.Entities;

namespace ServerCQRS.Application.Members.Queries
{
    public class GetMemberByIdQuery : IRequest<Member>
    {
        public int Id { get; set; }

        public class GetMemberByIdQueryHandler : IRequestHandler<GetMemberByIdQuery, Member>
        {
            private readonly IMemberDapperRepository _memberDapperRepository;

            public GetMemberByIdQueryHandler(IMemberDapperRepository memberDapperRepository)
            {
                _memberDapperRepository = memberDapperRepository;
            }

            public async Task<Member> Handle(GetMemberByIdQuery request, CancellationToken cancellationToken)
            {
                var member = await _memberDapperRepository.GetMemberById(request.Id);
                return member;
            }
        }
    }
}
