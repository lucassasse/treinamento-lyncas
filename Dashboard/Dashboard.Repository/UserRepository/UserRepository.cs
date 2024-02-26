using Dashboard.Domain.Models;
using Dashboard.Repository.Repository;
using Domain.Data;

namespace Dashboard.Repository.UserRepository
{
    public class UserRepository : Repository<User> , IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }
    }
}
