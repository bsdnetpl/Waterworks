using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Waterworks.DTO;
using Waterworks.Service;

namespace Waterworks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersPaymenController : ControllerBase
    {
        private readonly ICustomersPaymentService _customersPaymentService;

        public CustomersPaymenController(ICustomersPaymentService customersPaymentService)
        {
            _customersPaymentService = customersPaymentService;
        }

        [HttpPost("AddPayment")]
        public ActionResult<bool> AddPayment(CustomersPaymentDTO customersPaymentDTO, Guid idUser)
        {
            if (ModelState.IsValid)
            {
                return Ok(_customersPaymentService.AddPayment(customersPaymentDTO,idUser));
            }
            return NotFound(false);
        }

        [HttpPut("EditPayment")]
        public ActionResult<bool>EditPayment(CustomersPaymentDTO customersPaymentDTO, Guid idPayment, Guid IdEployee)
        {
            if (ModelState.IsValid)
            {
                return Ok(_customersPaymentService.EditPayment(customersPaymentDTO,idPayment,IdEployee));
            }
            return NotFound(false);
        }

    }
}
