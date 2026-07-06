using Microsoft.AspNetCore.Components.Web;
using PaymentManagementAPI.DTOs;
using PaymentManagementAPI.Models;

namespace PaymentManagementAPI.Interfaces
{
    public interface IPaymentRepository
    {
        List<Payment> GetAllPayments();
        Payment? GetPaymentByID(int id);
        //bool DeletePaymentByID(int id);

        //bool UpadtePayment(int id, UpdatePaymentdto dto);
        ////bool UpdateSelected(Payment payment);
        void AddPayment(Payment payment);
        //bool TransferMoney(TransferMoneyDtocs dto);

    }
}
