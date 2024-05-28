using ServerCQRS.Domain.Abstractions;
using ServerCQRS.Infrastructure.Context;

namespace ServerCQRS.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private IMemberRepository? _memberRepo;
        private ICustomerRepository? _customerRepo;
        private ISaleRepository? _saleRepo;
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IMemberRepository MemberRepository
        {
            get
            {
                return _memberRepo = _memberRepo ??
                    new MemberRepository(_context);
            }
        }

        public ICustomerRepository CustomerRepository 
        {
            get
            {
                return _customerRepo = _customerRepo ??
                    new CustomerRepository(_context);
            }
        }

        public ISaleRepository SaleRepository
        {
            get
            {
                return _saleRepo = _saleRepo ??
                    new SaleRepository(_context);
            }
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
