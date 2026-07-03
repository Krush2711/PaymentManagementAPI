using PaymentManagementAPI.Models;

namespace PaymentManagementAPI.Interfaces
{
    public interface IPaymentService
    {
        List<Payment> GetAllPayments();
    }
}

