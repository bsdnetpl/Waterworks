using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Waterworks.DTO;

namespace Waterworks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet("GetCustomer")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetCustomer(Guid guidCustomer)
        {
            if (ModelState.IsValid)
            {
                return Ok(_customerService.GetCustomers(guidCustomer));
            }
            return BadRequest();
        }
        [HttpPost("AddCustomer")]
        public async Task<ActionResult<bool>> AddCustomer(Employee employee)
        {
            if (ModelState.IsValid)
            {
                return Ok(_customerService.AddCustomer(customerDTO));
            }
            return BadRequest();
        }
        [HttpPut("EditCustomer")]
        public async Task<ActionResult<Employee>> EditCustomer(Employee employee)
        {
            return _customerService.EditCustomer(customerId, customerDTO);
        }
    }
}
