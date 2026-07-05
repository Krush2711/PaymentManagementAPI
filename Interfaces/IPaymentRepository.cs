using Microsoft.AspNetCore.Components.Web;
using PaymentManagementAPI.Models;

namespace PaymentManagementAPI.Interfaces
{
    public interface IPaymentRepository
    {
        List<Payment> GetAllPayments();
        void Addpayment(Payment payment);
        Payment? GetPaymentByID(int id);
        bool DeletePaymentByID(int id);

        bool UpadtePayment(Payment payment);
        //bool UpdateSelected(Payment payment);
    }
}
