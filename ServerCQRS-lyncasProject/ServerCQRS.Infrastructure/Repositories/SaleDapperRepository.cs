using Dapper;
using ServerCQRS.Domain.Abstractions;
using ServerCQRS.Domain.Entities;
using System.Data;

namespace ServerCQRS.Infrastructure.Repositories
{
    public class SaleDapperRepository : ISaleDapperRepository
    {
        private readonly IDbConnection _dbConnection;

        public SaleDapperRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Sale> GetSaleById(int id)
        {
            string query = "SELECT * FROM Sales WHERE Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Sale>(query, new { Id = id });
        }

        public async Task<IEnumerable<Sale>> GetSales()
        {
            string query = "SELECT * FROM Sales";
            return await _dbConnection.QueryAsync<Sale>(query);
        }
    }
}
