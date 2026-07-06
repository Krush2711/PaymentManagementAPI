using System.ComponentModel.DataAnnotations;

namespace PaymentManagementAPI.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [MaxLength]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Phone]
        [MaxLength(10)]
        public string PhoneNumber { get; set; }

        [Required]
        public decimal Balance { get; set; }
        
        public DateTime CreatedDate { get; set; }

        // Navigation Properties
        public ICollection<Payment> SentPayments { get; set; } // ICollection<Payment> is another collection type that EF Core prefers for navigation properties.

        public ICollection<Payment> ReceivedPayments { get; set; }


    }
}
