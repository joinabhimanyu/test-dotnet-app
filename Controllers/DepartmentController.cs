using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test_dotnet_app.DTO;
using test_dotnet_app.Entities;
using test_dotnet_app.Services.DepartmentFeature;

namespace test_dotnet_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ILogger<DepartmentController> _logger;
        private readonly IDepartmentService _service;

        public DepartmentController(ILogger<DepartmentController> logger, IDepartmentService service)
        {
            _logger = logger;
            _service = service;
        }

        // GET: api/Department
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            return Ok(await _service.GetAllAsync(true));
        }

        // GET: api/Department/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            var department = await _service.GetByIdAsync(id, true);
            if (department == null)
            {
                return NotFound();
            }
            return department;
        }
        // search department
        [HttpPost("search")]
        public async Task<ActionResult<IEnumerable<Department>>> SearchDepartments([FromBody] List<SearchParam>? searchParams = null)
        {
            return await _service.SearchAsync(searchParams, true);
        }
        // PUT: api/Department/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(int id, Department department)
        {
            if (id!= department.Id)
            {
                return BadRequest();
            }
            await _service.UpdateAsync(department);
            return NoContent();
        }
        // POST: api/Department
        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment(Department department)
        {
            await _service.AddAsync(department);
            return CreatedAtAction("GetDepartment", new { id = department.Id }, department);
        }
        // DELETE: api/Department/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Department>> DeleteDepartment(int id)
        {
            var department = await _service.GetByIdAsync(id, false);
            if (department == null)
            {
                return NotFound();
            }
            await _service.DeleteAsync(id);
            return department;
        }
    }
}
