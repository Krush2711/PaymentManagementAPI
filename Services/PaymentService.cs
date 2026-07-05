using Microsoft.AspNetCore.Components.Web;
using PaymentManagementAPI.DTOs;
using PaymentManagementAPI.Interfaces;
using PaymentManagementAPI.Models;


namespace PaymentManagementAPI.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public void AddPayment(Payment payment)
        {
            _paymentRepository.Addpayment(payment);
        }

        public Payment? GetPaymentByID( int id)
        {
            return _paymentRepository.GetPaymentByID(id);
        }

        public bool DeletePaymentByID(int id)
        {
            return _paymentRepository.DeletePaymentByID(id);
        }

        public bool UpadtePayment(int id,CreatePaymentDto dto)
        {
            return _paymentRepository.UpadtePayment(id, dto);
        }
        public List<Payment> GetAllPayments()
        {
            return _paymentRepository.GetAllPayments();
        }
}
}
