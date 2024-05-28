namespace ServerCQRS.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        IMemberRepository MemberRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        ISaleRepository SaleRepository { get; }
        Task CommitAsync();
    }
}
