using Microsoft.EntityFrameworkCore;
using ServerCQRS.Domain.Abstractions;
using ServerCQRS.Domain.Entities;
using ServerCQRS.Infrastructure.Context;

namespace ServerCQRS.Infrastructure.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        protected readonly AppDbContext db;

        public MemberRepository(AppDbContext _db)
        {
            db = _db;
        }

        public async Task<Member> AddMember(Member member)
        {
            if (member is null) 
                throw new ArgumentNullException(nameof(member));

            await db.Members.AddAsync(member);
            return member;
        }

        public async Task<Member> DeleteMember(int memberId)
        {
            var member = await GetMemberById(memberId);

            if (member is null)
                throw new InvalidOperationException("Member not found");

            db.Members.Remove(member);
            return member;
        }

        public async Task<Member> GetMemberById(int memberId)
        {
            var member = await db.Members.FirstAsync();

            if (member is null)
                throw new InvalidOperationException("Member not found");

            return member;
        }

        public async Task<IEnumerable<Member>> GetMembers()
        {
            var memberList = await db.Members.ToListAsync();
            return memberList ?? Enumerable.Empty<Member>();
        }

        public void UpdateMember(Member member)
        {
            if (member is null)
                throw new ArgumentNullException(nameof(member));

            db.Members.Update(member);
        }
    }
}
