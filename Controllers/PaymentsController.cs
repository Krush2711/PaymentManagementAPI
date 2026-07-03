using Microsoft.AspNetCore.Http; // same like the import pandas as pd -> it is the existing class that we are going to use.
using Microsoft.AspNetCore.Mvc;
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


        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
    }
}
