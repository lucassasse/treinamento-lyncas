using Dapper;
using ServerCQRS.Domain.Abstractions;
using ServerCQRS.Domain.Entities;
using System.Data;

namespace ServerCQRS.Infrastructure.Repositories
{
    public class MemberDapperRepository : IMemberDapperRepository
    {
        private readonly IDbConnection _dbConnection;

        public MemberDapperRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Member> GetMemberById(int id)
        {
            string query = "SELECT * FROM Members WHERE Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Member>(query, new { Id = id });
        }

        public async Task<IEnumerable<Member>> GetMembers()
        {
            string query = "SELECT * FROM Members";
            return await _dbConnection.QueryAsync<Member>(query);
        }
    }
}
