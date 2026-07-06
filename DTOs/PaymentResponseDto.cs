using PaymentManagementAPI.Models;

namespace PaymentManagementAPI.DTOs
{
    public class PaymentResponseDto
    {
        public int PaymentId { get; set; }

        public int SenderId { get; set; }

        public int ReceiverId { get; set; }

        public decimal Amount { get; set; }

        public PaymentMethodsEnum PaymentMethod { get; set; }

        public string Status { get; set; }

        public DateTime TransactionDate { get; set; }

        public string? Note { get; set; }
    }
}