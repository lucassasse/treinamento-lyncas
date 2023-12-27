using WebAPI.Models;

namespace WebAPI.Repositories.Interfaces
{
    public interface IUserRepositorie
    {
        Task<List<UserModel>> SearchAllUsers();
        Task<UserModel> SearchForId(int id);
        Task<UserModel> Create(UserModel user);
        Task<UserModel> Update(UserModel user, int id);
        Task<bool> Delete(int id);
    }
}
