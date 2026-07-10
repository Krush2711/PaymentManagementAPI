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
        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public IActionResult GetAllPayments()
        {
            var payments = _paymentService.GetAllPayments();

            if (payments == null)
            {
                return NotFound("Payments not exists ");
            }

            return Ok(payments);
        }

            [HttpPost("transfer")]
        public IActionResult TransferMoney(TransferMoneyDtocs dto)
        {
            var result = _paymentService.TransferMoney(dto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetPaymentById(int id)
        {
            var payment = _paymentService.GetPaymentById(id);
            if (payment == null)
            {
                return BadRequest("Transfer Failed");
            }

            return Ok(payment);
        }


    }
}

