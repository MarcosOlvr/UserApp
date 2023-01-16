using UserApi.Models;

namespace UserApi.Repository.Contracts
{
    public interface IUserRepository
    {
        User CreateUser(User model);
        bool DeleteUser(int id);
        User UpdateUser(int id, User model);
        User GetUser(int id); 
    }
}
