namespace PaymentManagementAPI.Models
{
    public class Payment
    {
        public int PaymnetId { get; set; }
        public string PayerName { get; set; } = string.Empty;

        public decimal Amount { get; set; }

        public string PaymentMethod  { get; set; } = string.Empty; // prevents c# to convert -> null vales 

        public DateTime PaymnetDate { get; set; }

        public string Status { get; set; } = String.Empty;


    }
}
