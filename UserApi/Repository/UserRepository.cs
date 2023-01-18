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

        public User CreateUser(User model)
        {
            try
            {
                if (model == null)
                    throw new ArgumentNullException("model");

                _db.Users.Add(model);

                _db.SaveChanges();

                return model;
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

                if (user == null)
                    throw new Exception();

                return user;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public User UpdateUser(int id, User model)
        {
            try
            {
                User user = GetUser(id);

                user.Name = model.Name;
                user.Email = model.Email;
                user.Password = model.Password;
                
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
