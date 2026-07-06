using PaymentManagementAPI.Models;

namespace PaymentManagementAPI.DTOs
{
    public class CreatePaymentDto
    {
        public string PayerName { get; set; }
        public decimal Amount {  get; set; }    
        public PaymentMethodsEnum PaymentMethod { get; set; }
    }
}
