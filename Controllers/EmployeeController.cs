using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using test_dotnet_app.DTO;
using test_dotnet_app.Entities;
using test_dotnet_app.Services.EmployeeFeature;
using test_dotnet_app.Utils;

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
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees()
        {
            return Ok(await _service.GetAllAsync(true));
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployee(int id)
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
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> SearchEmployees([FromBody] List<SearchParam>? searchParams = null)
        {
            var result=await _service.SearchAsync(searchParams, true);
            return Ok(result);
        }
        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, [FromBody] EmployeeDto employee)
        {
            if (id!= employee.Id)
            {
                _logger.LogError($"Employee {id} does not exist in employee");
                ModelState.TryAddModelError(CustomErroCodes.EntityNotFoundException.GetDisplayName(), $"Employee {id} does not exist in employee");
                return BadRequest(ModelState);
            }
            else if(!ModelState.IsValid)
            {
                _logger.LogError($"Employee payload is invalid. Validation failed with errors: {ModelState.Select(x=>new {x.Key, x.Value}).ToList().ToString()}");
                return BadRequest(ModelState);
            }
            await _service.UpdateAsync(employee);
            return NoContent();
        }
        // POST: api/Employee
        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> PostEmployee([FromBody] EmployeeDto employee)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Employee payload is invalid. Validation failed with errors: {ModelState.Select(x=>new {x.Key, x.Value}).ToList().ToString()}");
                return BadRequest(ModelState);
            }
            await _service.AddAsync(employee);
            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }
        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeDto>> DeleteEmployee(int id)
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
