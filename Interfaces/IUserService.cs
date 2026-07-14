using PaymentManagementAPI.DTOs.User;
using static PaymentManagementAPI.DTOs.User.DataAnnotations;

namespace PaymentManagementAPI.Interfaces
{
    public interface IUserService
    {
        List<UserResponseDto> GetAllUsers();

        UserResponseDto? GetUserById(int id);

        UserResultDto AddUser(CreateUserDto dto);

        bool UpdateUser(int id, UpdateUserDto dto);

        bool DeleteUser(int id);
        bool SoftDeleteUser(int id);
    }
}
