using Microsoft.AspNetCore.Components.Web;
using PaymentManagementAPI.Data;
using PaymentManagementAPI.DTOs;
using PaymentManagementAPI.Interfaces;
using PaymentManagementAPI.Models;


namespace PaymentManagementAPI.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IUserRepository _userRepository;
        private readonly AppDbContext _context;

        public PaymentService(IPaymentRepository paymentRepository, IUserRepository userRepository, AppDbContext context)
        {
            _paymentRepository = paymentRepository;
            _userRepository = userRepository;
            _context = context;
        }

        //public void AddPayment(Payment payment)
        //{
        //    _paymentRepository.Addpayment(payment);
        //}

        //public Payment? GetPaymentByID( int id)
        //{
        //    return _paymentRepository.GetPaymentByID(id);
        //}

        //public bool DeletePaymentByID(int id)
        //{
        //    return _paymentRepository.DeletePaymentByID(id);
        //}

        //public bool UpadtePayment(int id,CreatePaymentDto dto)
        //{
        //    return _paymentRepository.UpadtePayment(id, dto);
        //}
        public List<PaymentResponseDto> GetAllPayments()
        {
            var payments = _paymentRepository.GetAllPayments();

            return payments.Select(p => new PaymentResponseDto
            {
                PaymentId = p.PaymentId,
                SenderId = p.SenderId,
                ReceiverId = p.ReceiverId,
                Amount = p.Amount,
                PaymentMethod = p.PaymentMethod,
                Status = p.Status,
                TransactionDate = p.TransactionDate,
                Note = p.Note
            }).ToList();
        }

        public PaymentResponseDto? GetPaymentById(int id)
        {
            var payment = _paymentRepository.GetPaymentByID(id);

            if (payment == null)
                return null;

            return new PaymentResponseDto
            {
                PaymentId = payment.PaymentId,
                SenderId = payment.SenderId,
                ReceiverId = payment.ReceiverId,
                Amount = payment.Amount,
                PaymentMethod = payment.PaymentMethod,
                Status = payment.Status,
                TransactionDate = payment.TransactionDate,
                Note = payment.Note
            };
        }
        public DtostranseferResult TransferMoney(TransferMoneyDtocs dto)
        {
            // Get Sender
            var sender = _userRepository.GetUserById(dto.SenderID);

            // Get Receiver
            var receiver = _userRepository.GetUserById(dto.ReceiverId);

            // Validate Users
            if (sender == null)
            {
                return new DtostranseferResult
                {
                    Success = false,
                    Message = "Sender Not found"
                };
            }

            if (receiver == null)
            {
                return new DtostranseferResult
                {
                    Success = false,
                    Message = "reciver not found"
                };
            }


            //  Self Transfer
            if (sender.UserId == receiver.UserId)
            {
                return new DtostranseferResult
                {
                    Success = false,
                    Message = "Self transfer is not allowed."
                };
            }

            // Check Balance
            if (sender.Balance < dto.Amount)
            {
                return new DtostranseferResult
                {
                    Success = false,
                    Message = "Insufficient balance."
                };
            }

            if (dto.Amount <= 0)
            {
                return new DtostranseferResult
                {
                    Success = false,
                    Message = "Amount should be greater than zero."
                };
            }
            // Deduct Sender Balance
            sender.Balance -= dto.Amount;

            // Credit Receiver Balance
            receiver.Balance += dto.Amount;

            // Create Transaction
            var payment = new Payment
            {
                SenderId = dto.SenderID,
                ReceiverId = dto.ReceiverId,
                Amount = dto.Amount,
                PaymentMethod = dto.paymentMethod,
                Note = dto.Note,
                Status = "Success",
                TransactionDate = DateTime.Now
            };

            _userRepository.UpdateBalance(sender);

            _userRepository.UpdateBalance(receiver);

            _paymentRepository.AddPayment(payment);

            _context.SaveChanges();

            return new DtostranseferResult
            {
                Success = true,
                Message = "Money Transferd Successfully",
                PaymnetId = payment.PaymentId
            };
            throw new Exception("Database Failed");
        }
    }
}