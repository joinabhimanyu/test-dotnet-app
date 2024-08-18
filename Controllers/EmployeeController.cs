using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test_dotnet_app.DTO;
using test_dotnet_app.Entities;
using test_dotnet_app.Services.EmployeeFeature;

namespace test_dotnet_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeService _service;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService service)
        {
            _logger = logger;
            _service = service;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _service.GetAllAsync(true);
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _service.GetByIdAsync(id, true);
            if (employee == null)
            {
                return NotFound();
            }
            return employee;
        }
        // search employee
        [HttpPost("search")]
        public async Task<ActionResult<IEnumerable<Employee>>> SearchEmployees([FromBody] List<SearchParam>? searchParams = null)
        {
            return await _service.SearchAsync(searchParams, true);
        }
        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id!= employee.Id)
            {
                return BadRequest();
            }
            await _service.UpdateAsync(employee);
            return NoContent();
        }
        // POST: api/Employee
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            await _service.AddAsync(employee);
            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }
        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var employee = await _service.GetByIdAsync(id, false);
            if (employee == null)
            {
                return NotFound();
            }
            await _service.DeleteAsync(id);
            return employee;
        }
    }
}