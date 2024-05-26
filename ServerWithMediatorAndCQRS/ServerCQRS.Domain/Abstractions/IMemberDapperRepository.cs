using ServerCQRS.Domain.Entities;

namespace ServerCQRS.Domain.Abstractions
{
    public interface IMemberDapperRepository
    {
        Task<IEnumerable<Member>> GetMembers();
        Task<Member> GetMemberById(int id);
    }
}
