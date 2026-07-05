using PaymentManagementAPI.Data;
using PaymentManagementAPI.Interfaces;
using PaymentManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
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

        public bool UpadtePayment(Payment payment)
        {
            var existingpayment = _context.Payments.Find(payment.PaymentId);
            if (existingpayment != null)
            {
                existingpayment.PayerName = payment.PayerName;
                existingpayment.PaymentMethod = payment.PaymentMethod;
                existingpayment.Status = payment.Status;
                existingpayment.Amount = payment.Amount;
                // shortcut -> 
                //_context.Payments.Update(payment);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        //public bool UpdateSelected(Payment payment)
        //{
          
        //    _context.Payments.Update(payment);
        //    _context.SaveChanges();
        //}



    }
}
