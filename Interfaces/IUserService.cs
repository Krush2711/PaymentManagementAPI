using PaymentManagementAPI.DTOs.User;
using static PaymentManagementAPI.DTOs.User.DataAnnotations;

namespace PaymentManagementAPI.Interfaces
{
    public interface IUserService
    {
        List<UserResponseDto> GetAllUsers();

        UserResponseDto? GetUserById(int id);

        void AddUser(CreateUserDto dto);

        bool UpdateUser(int id, UpdateUserDto dto);

        bool DeleteUser(int id);
    }
}
