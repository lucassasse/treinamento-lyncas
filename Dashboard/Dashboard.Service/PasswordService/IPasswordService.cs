using Dashboard.Domain.Models;

namespace Dashboard.Service.PasswordService
{
    public interface IPasswordService
    {
        void CreateHashPassword(string password, out byte[] hashPassword, out byte[] saltPassword);
        bool VerifyHashPassword(string password, byte[] hashPassword, byte[] saltPassword);
        string CreateToken(User user);
    }
}
