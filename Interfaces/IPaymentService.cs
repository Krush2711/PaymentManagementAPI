using PaymentManagementAPI.DTOs;
using PaymentManagementAPI.Models;

namespace PaymentManagementAPI.Interfaces
{
    public interface IPaymentService
    {
        List<PaymentResponseDto> GetAllPayments();
        //void AddPayment(Payment payment);
        //Payment? GetPaymentByID(int id);

        //bool UpadtePayment(int id, CreatePaymentDto dto);
        //bool DeletePaymentByID(int id);
        //bool UpdateSelected(Payment payment);

        PaymentResponseDto ? GetPaymentById(int id);
        DtostranseferResult TransferMoney(TransferMoneyDtocs dto);

    }

}

