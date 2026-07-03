using Microsoft.AspNetCore.Http; // same like the import pandas as pd -> it is the existing class that we are going to use.
using Microsoft.AspNetCore.Mvc;
using PaymentManagementAPI.Models; // this is the created class / folder we are going to use. tells the C# controller  -> Payment inside the controller

namespace PaymentManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetResult()
        {
            var payments = new List<Payment>()
            {
                new Payment
                {
                    PaymnetId = 1,
                    PayerName = "Krushna",
                    Amount = 500,
                    PaymentMethod = "UPI",
                    PaymnetDate =  DateTime.Now,
                    Status = "Success"
                },
                new Payment
                {
                    PaymnetId = 2,
                    PayerName = "Rahul",
                    Amount = 1990,
                    PaymentMethod = "Credit Card",
                    PaymnetDate =  DateTime.Now,
                    Status = "Pending"
                },
            };

            return Ok(payments);
        }
    }
}
