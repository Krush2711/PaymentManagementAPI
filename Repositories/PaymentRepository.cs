using Microsoft.EntityFrameworkCore;
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

        public Payment ? GetPaymentByID(int id)
        {
            return _context.Payments.Find(id);
        }


        public void Addpayment(Payment payment)
        {
            _context.Payments.Add(payment);
            _context.SaveChanges();
        }

        public bool DeletePaymentByID(int id)
        {
            var payment = _context.Payments.Find(id);
            if (payment != null)
            {
                _context.Payments.Remove(payment);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpadtePayment(int id , CreatePaymentDto dto)
        {
            var existingpayment = _context.Payments.Find(id);
            if (existingpayment != null)
            {
                existingpayment.PayerName = dto.PayerName;
                existingpayment.PaymentMethod = dto.PaymentMethod;
                existingpayment.Amount = dto.Amount;
                // shortcut -> 
                //_context.Payments.Update(payment);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
       



    }
}
