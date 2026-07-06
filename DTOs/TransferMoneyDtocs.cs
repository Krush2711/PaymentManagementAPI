using PaymentManagementAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace PaymentManagementAPI.DTOs
{
    public class TransferMoneyDtocs
    {
        [Required]
        public int SenderID { get; set; }

        [Required ]
        public int Receiver {  get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required ]
        public PaymentMethodsEnum paymentMethod { get; set; }

        [MaxLength(100)]
        public string? Note { get; set; }


    }
}
