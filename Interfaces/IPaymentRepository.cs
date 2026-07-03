using PaymentManagementAPI.Models;

namespace PaymentManagementAPI.Interfaces
{
    public interface IPaymentRepository
    {
        List<Payment> GetAllPayments();
    }
}
