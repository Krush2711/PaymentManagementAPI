using PaymentManagementAPI.Data;
using PaymentManagementAPI.Interfaces;
using PaymentManagementAPI.Models;


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
            return new List<Payment>(); 
        }



    }
}
