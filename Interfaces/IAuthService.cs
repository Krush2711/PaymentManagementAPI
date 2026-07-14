using PaymentManagementAPI.DTOs.Auth;
using PaymentManagementAPI.DTOs.User;

namespace PaymentManagementAPI.Interfaces
{
    public interface IAuthService
    {
        UserResultDto Register(RegisterDto dto);
        LoginResponseDto ? Login (LoginDto login);
    }
}
