using PaymentManagementAPI.DTOs.User;
using PaymentManagementAPI.Interfaces;
using PaymentManagementAPI.Models;
using static PaymentManagementAPI.DTOs.User.DataAnnotations;


namespace PaymentManagementAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUser(CreateUserDto dto)
        {
            var user = new User
            {
                UserName = dto.Name,
                EmailAddress = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Balance = dto.Balance,
                CreatedDate = DateTime.Now
            };

            _userRepository.AddUser(user);
        }

        public List<UserResponseDto> GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();

            return users.Select(u => new UserResponseDto
            {
                UserId = u.UserId,
                Name = u.UserName,
                Email = u.EmailAddress,
                PhoneNumber = u.PhoneNumber,
                Balance = u.Balance
            }).ToList();
        }


        public UserResponseDto? GetUserById(int id)
        {
            var user = _userRepository.GetUserById(id);

            if (user == null)
                return null;

            return new UserResponseDto
            {
                UserId = user.UserId,
                Name = user.UserName,
                Email = user.EmailAddress,
                PhoneNumber = user.PhoneNumber,
                Balance = user.Balance
            };
        }

        public bool UpdateUser(int id, UpdateUserDto dto)
        {
            var user = new User
            {
                UserId = id,
                UserName = dto.Name,
                PhoneNumber = dto.PhoneNumber
            };

            return _userRepository.UpdateUser(id , user);
        }

        public bool DeleteUser(int id)
        {
            return _userRepository.DeleteUser(id);
        }

    }

}
