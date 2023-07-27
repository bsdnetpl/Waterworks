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

        //  [HttpGet("GetCustomer")]
        [HttpPost("AddCustomer")]
        public async Task<ActionResult<bool>>AddCustomer(CustomerDTO customerDTO)
        {
            return Ok(_customerService.AddCustomer(customerDTO));
        }
       // [HttpPut("EditCustomer")]
    }
}
