using PaymentManagementAPI.Interfaces;
using PaymentManagementAPI.Models;


namespace PaymentManagementAPI.Services
{
    public class PaymentService : IPaymentService
    {
        public List<Payment> GetAllPayments()
        {
            return new List<Payment>()
            {
                new Payment
                {
                    PaymentId = 1,
                    PayerName = "Krushna",
                    Amount = 500,
                    PaymentMethod = "UPI",
                    PaymentDate = DateTime.Now,
                    Status = "Success"

                },
                new Payment
                {
                    PaymentId = 2,
                    PayerName = "Rahul",
                    Amount = 1200,
                    PaymentMethod = "Credit Card",
                    PaymentDate = DateTime.Now,
                    Status = "Pending"
                }
            };
        }
    }
}
