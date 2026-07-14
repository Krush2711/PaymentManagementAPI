namespace PaymentManagementAPI.DTOs.User
{
    public class UserResponseDto
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public decimal Balance { get; set; }

        public string Role { get; set; }
    }
}
