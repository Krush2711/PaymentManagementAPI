using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PaymentManagementAPI.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }


        [Required]
        public int SenderId { get; set; } 
        [Required]
        public int ReceiverId { get; set; } 

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public PaymentMethodsEnum PaymentMethod { get; set; }
        public string Status { get; set; }

        public DateTime TransactionDate { get; set; }

        [ForeignKey(nameof(SenderId))]
        public User Sender { get; set; }

        [ForeignKey(nameof(ReceiverId))]
        public User Receiver { get; set; }

        [MaxLength(100)]
        public string? Note { get; set; }



    }
}
