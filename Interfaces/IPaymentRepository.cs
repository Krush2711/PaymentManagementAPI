using PaymentManagementAPI.Models;

namespace PaymentManagementAPI.Interfaces
{
    public interface IPaymentRepository
    {
        List<Payment> GetAllPayments();
        void Addpayment(Payment payment);
        Payment? GetPaymentByID(int id);
    }
}
