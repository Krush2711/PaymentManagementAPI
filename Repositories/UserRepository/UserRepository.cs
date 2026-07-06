using PaymentManagementAPI.Data;
using PaymentManagementAPI.Interfaces;
using PaymentManagementAPI.Models;

namespace PaymentManagementAPI.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User? GetUserById(int id)
        {
            return _context.Users.Find(id);
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public bool UpdateUser(int id , User user)
        {
            var existinguser = _context.Users.Find(id);
            if (existinguser == null)
            {
                return false;
            }
            existinguser.UserName = user.UserName;
            existinguser.PhoneNumber = user.PhoneNumber;
            _context.SaveChanges();
            return true;
        }

        public bool DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if(user == null)
            {
                return false;
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        }
}
}


