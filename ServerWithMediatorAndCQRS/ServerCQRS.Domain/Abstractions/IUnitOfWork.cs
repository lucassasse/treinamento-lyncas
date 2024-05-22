namespace ServerCQRS.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        IMemberRepository MemberRepository { get; }
        Task CommitAsync();
    }
}
