using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Waterworks.DTO;
using Waterworks.Service;

namespace Waterworks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("GetCustomer")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetCustomer(Guid guidCustomer)
        {
            if (ModelState.IsValid)
            {
                return Ok(_employeeService.GetEmployee(guidCustomer));
            }
            return BadRequest();
        }
        [HttpPost("AddCustomer")]
        public async Task<ActionResult<bool>> AddCustomer(Employee employee)
        {
            if (ModelState.IsValid)
            {
                return Ok(_employeeService.AddEmployeer(employee));
            }
            return BadRequest();
        }
        [HttpPut("EditCustomer")]
        public async Task<ActionResult<Employee>> EditCustomer(Employee employee)
        {
            return _employeeService.EditEmployee(employee);
        }
    }
}
