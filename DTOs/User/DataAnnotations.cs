using System.ComponentModel.DataAnnotations;

namespace PaymentManagementAPI.DTOs.User
{
    public class DataAnnotations
    {
        public class CreateUserDto
        {
            [Required]
            [StringLength(50)]
            public string Name { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Phone]
            public string PhoneNumber { get; set; }

            [Range(0, 10000000)]
            public decimal Balance { get; set; }
        }

    }
}
