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

        [HttpGet("GetEmployee")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee(Guid guidCustomer)
        {
            if (ModelState.IsValid)
            {
                return Ok(_employeeService.GetEmployee(guidCustomer));
            }
            return BadRequest();
        }
        [HttpPost("AddEmployee")]
        public async Task<ActionResult<bool>> AddEmployeer(Employee employee)
        {
            if (ModelState.IsValid)
            {
                return Ok(_employeeService.AddEmployeer(employee));
            }
            return BadRequest();
        }
        [HttpPut("EditEmployee")]
        public async Task<ActionResult<Employee>> EditEmployee(Employee employee)
        {
            return _employeeService.EditEmployee(employee);
        }
    }
}
