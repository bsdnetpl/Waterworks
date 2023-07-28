using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Waterworks.DTO;
using Waterworks.Service;

namespace Waterworks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
      private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("GetCustomer")]
        public async Task<ActionResult <IEnumerable<Customer>>> GetCustomer(Guid guidCustomer) 
        {
            if (ModelState.IsValid)
            {
                return Ok(_customerService.GetCustomers(guidCustomer));
            }
            return BadRequest();
        }
        [HttpPost("AddCustomer")]
        public async Task<ActionResult<bool>>AddCustomer(CustomerDTO customerDTO)
        {
            if (ModelState.IsValid)
            {
                return Ok(_customerService.AddCustomer(customerDTO));
            }
            return BadRequest();
        }
        [HttpPut("EditCustomer")]
        public async Task<ActionResult<Customer>> EditCustomer(Guid customerId, CustomerDTO customerDTO)
        {
              return  _customerService.EditCustomer(customerId, customerDTO);
        }
    }
}
