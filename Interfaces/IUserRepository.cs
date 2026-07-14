using PaymentManagementAPI.Models;
using PaymentManagementAPI.DTOs.User;
namespace PaymentManagementAPI.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User? GetUserById  (int id);
        void AddUser(User user);
        bool UpdateUser( int id , User user);
        bool  DeleteUser(int id);
        void UpdateBalance(User user);
        bool EmailExists(string email);
        User? GetUserByEmail(string email);
        bool SoftDeleteUser(int id);
        bool PhoneExists(string phoneNumber);
    }
}
