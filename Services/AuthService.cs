using BCrypt.Net;
using Microsoft.AspNetCore.Identity;
using PaymentManagementAPI.DTOs.Auth;
using PaymentManagementAPI.DTOs.User;
using PaymentManagementAPI.Interfaces;
using PaymentManagementAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Net.Sockets;


namespace PaymentManagementAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        private string GenrateJwtToken(User user)
        {
            // claims -> (jwt-> digiatal id card) 
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email , user.EmailAddress),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(
                    Convert.ToDouble(_configuration["JWt:ExpireMinutes"])),
                signingCredentials: credentials);
                
            return new JwtSecurityTokenHandler().WriteToken(token);


        }
        public UserResultDto Register(RegisterDto dto)
        {
            // Email vaildation
            if (_userRepository.EmailExists(dto.Email))
            {
                return new UserResultDto
                {
                    Success = false,
                    Message = "Email already Exists."
                };

            }

            // Phone validation
            if (_userRepository.PhoneExists(dto.PhoneNumber))
            {
                return new UserResultDto
                {
                    Success = false,
                    Message = "Phone number already exists."
                };
            }

            // Hash password
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            var user = new User
            {
                UserName = dto.Name,
                EmailAddress = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                PasswordHash = passwordHash,
                Balance = dto.Balance,
                Role = "User",
                //IsActive = true,
            };

            _userRepository.AddUser(user);

            return new UserResultDto
            {
                Success = true,
                Message = "Registration Sucessful",
                UserId = user.UserId
            };
        }

        public LoginResponseDto? Login(LoginDto dto)
        {
            var user = _userRepository.GetUserByEmail(dto.Email);
            if (user == null)
            {
                return null;
            }
            bool isPasswordCorrect = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);

            if (!isPasswordCorrect)
            {
                return null;
            }
            string token = GenrateJwtToken(user);

            return new LoginResponseDto
            {
                Token = token,
                Email = dto.Email,
                Role = user.Role
            };
        }
    }
}
