using UserApi.Data;
using UserApi.Models;
using UserApi.Repository.Contracts;

namespace UserApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;

        public UserRepository(AppDbContext db)
        {
            _db = db;
        }

        public bool CreateUser(string name, string email, string password)
        {
            try
            {
                _db.Users.Add(new User
                {
                    Name = name,
                    Email = email,
                    Password = password
                });

                _db.SaveChanges();

                return true;
            }
            catch(Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public bool DeleteUser(int id)
        {
            try
            {
                _db.Users.Remove(GetUser(id));
                _db.SaveChanges();

                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);    
            }
        }

        public User GetUser(int id)
        {
            try
            {
                User user = _db.Users.Find(id);

                return user;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public User UpdateUser(int id, string name, string email, string password)
        {
            try
            {
                User user = GetUser(id);
                user.Name = name;
                user.Email = email;
                user.Password = password;
                
                _db.Users.Update(user);
                _db.SaveChanges();

                return user;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
