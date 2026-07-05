using Microsoft.AspNetCore.Http; // same like the import pandas as pd -> it is the existing class that we are going to use.
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client.AppConfig;
using PaymentManagementAPI.DTOs;
using PaymentManagementAPI.Interfaces;
using PaymentManagementAPI.Models; // this is the created class / folder we are going to use. tells the C# controller  -> Payment ins

namespace PaymentManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService; // reference variable

        [HttpGet]
        public IActionResult GetResult() //Constructor = Receiving dependencies.
        {
             var payments = _paymentService.GetAllPayments();
             return Ok(payments);
        }

        [HttpPost]
        public IActionResult AddPayment(CreatePaymentDto dto)
        {
            //_paymentService.AddPayment(payment);
            //return Ok("Payment Added Successfully"); ---> without dto 

            Payment payment = new Payment()
            {
                // swagger input 
                PayerName = dto.PayerName, 
                Amount = dto.Amount,
                PaymentMethod  = dto.PaymentMethod, 

                // server input 
                PaymentDate = DateTime.Now,
                Status = "Pending"

            };
            _paymentService.AddPayment(payment);
            return Ok("Payment Added Successfully");

        }

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet("{id}")]
        public IActionResult GetPaymentByID(int id)
        {
            var paymnet = _paymentService.GetPaymentByID(id);

            if(paymnet != null)
            {
                return Ok(paymnet);
            }
            return NotFound("Payment id do not exist");
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePaymentByID(int id)
        {
            //var paymnet = _paymentService.GetPaymentByID(id);
            //if (paymnet != null)
            //{
            //    _paymentService.DeletePaymentByID(id);
            //    return Ok();
            //}
            //return NotFound("Payment id do not exist");
            // short code
            bool deleted = _paymentService.DeletePaymentByID(id);
            if (deleted)
            {
                return Ok("Payment is deleted ");
            }
            return NotFound("Payment id do not exist");

        }

        [HttpPut]
        public IActionResult UpadtePayment(Payment payment)
        {
            bool updated = _paymentService.UpadtePayment(payment);
            if (updated)
            {
                return Ok("Payment updated sucessfully.");
            }
            return BadRequest();
        }

        //[HttpPatch]
        //public IActionResult UpadtePayment(Payment payment)
        //{
        //    bool updated = _paymentService.UpadtePayment(payment);
        //    if (updated)
        //    {
        //        return Ok("Payment updated sucessfully.");
        //    }
        //    return BadRequest();
        //} 
    }
}
