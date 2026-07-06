using System.ComponentModel.DataAnnotations;

namespace PaymentManagementAPI.DTOs.User
{
    public class UpdateUserDto
    {
        
            [Required]
            [StringLength(50)]
            public string Name { get; set; }

            [Phone]
            public string PhoneNumber { get; set; }

            
    }
}
