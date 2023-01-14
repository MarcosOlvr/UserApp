using UserApi.Models;

namespace UserApi.Repository.Contracts
{
    public interface IUserRepository
    {
        bool CreateUser(string name, string email, string password);
        bool DeleteUser(int id);
        User UpdateUser(int id, string name, string email, string password);
        User GetUser(int id); 
    }
}
