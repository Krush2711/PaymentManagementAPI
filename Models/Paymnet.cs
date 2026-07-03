namespace PaymentManagementAPI.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public string PayerName { get; set; } = string.Empty;

        public decimal Amount { get; set; }

        public string PaymentMethod  { get; set; } = string.Empty; // prevents c# to convert -> null vales 

        public DateTime PaymentDate { get; set; }

        public string Status { get; set; } = String.Empty;


    }
}
