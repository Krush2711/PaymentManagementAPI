using PaymentManagementAPI.Data;
using PaymentManagementAPI.Interfaces;
using PaymentManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

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

        public Payment ? GetPaymentByID(int id)
        {
            return _context.Payments.Find(id);
        }


        public void Addpayment(Payment payment)
        {
            _context.Payments.Add(payment);
            _context.SaveChanges();
        }
    }
}