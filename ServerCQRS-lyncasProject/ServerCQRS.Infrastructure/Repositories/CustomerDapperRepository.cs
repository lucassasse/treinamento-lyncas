using Dapper;
using ServerCQRS.Domain.Abstractions;
using ServerCQRS.Domain.Entities;
using System.Data;

namespace ServerCQRS.Infrastructure.Repositories
{
    public class CustomerDapperRepository : ICustomerDapperRepository
    {
        private readonly IDbConnection _dbConnection;

        public CustomerDapperRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            string query = "SELECT * FROM Customer WHERE Id = @Id AND SoftDeleted <> 'true'";
            return await _dbConnection.QueryFirstOrDefaultAsync<Customer>(query, new { Id = id });
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            string query = "SELECT * FROM Customer";
            return await _dbConnection.QueryAsync<Customer>(query);
        }
    }
}
