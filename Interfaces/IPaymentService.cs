using PaymentManagementAPI.Models;

namespace PaymentManagementAPI.Interfaces
{
    public interface IPaymentService
    {
        List<Payment> GetAllPayments();
        void AddPayment(Payment payment);
        Payment? GetPaymentByID(int id);
        bool UpadtePayment(Payment payment);
        bool DeletePaymentByID(int id);
        //bool UpdateSelected(Payment payment);

    }

}

