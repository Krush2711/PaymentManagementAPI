using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using PaymentManagementAPI.Data;
using PaymentManagementAPI.DTOs;
using PaymentManagementAPI.Interfaces;
using PaymentManagementAPI.Models;
using System.Security.Principal;

namespace PaymentManagementAPI.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly AppDbContext _context;
        public PaymentRepository(AppDbContext context)
        {
            _context = context;
        }


        public List<Payment> GetAllPayments()
        {
            return _context.Payments.ToList();

        }

        public Payment? GetPaymentByID(int id)
        {
            return _context.Payments.Find(id);
        }

        public void AddPayment(Payment payment)
        {
            _context.Payments.Add(payment);
        }








    }
}
