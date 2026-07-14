using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
namespace PaymentManagementAPI.DTOs.Auth
{
    public class RegisterDto
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength (10)]
        public string PhoneNumber {  get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        public decimal Balance { get; set; }

    }
}
