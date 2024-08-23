using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using test_dotnet_app.DTO;
using test_dotnet_app.Entities;
using test_dotnet_app.Services.DepartmentFeature;
using test_dotnet_app.Utils;

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
        public async Task<ActionResult<IEnumerable<DepartmentDto>>> GetDepartments()
        {
            return Ok(await _service.GetAllAsync(true));
        }

        // GET: api/Department/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentDto>> GetDepartment(int id)
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
        public async Task<ActionResult<IEnumerable<DepartmentDto>>> SearchDepartments([FromBody] List<SearchParam>? searchParams = null)
        {
            var result=await _service.SearchAsync(searchParams, true);
            return Ok(result);
        }
        // PUT: api/Department/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(int id, [FromBody] DepartmentDto department)
        {
            if (id!= department.Id)
            {
                _logger.LogError($"Department {id} does not exist in department");
                ModelState.TryAddModelError(CustomErroCodes.EntityNotFoundException.GetDisplayName(), $"Department {id} does not exist in department");
                return BadRequest(ModelState);
            }
            else if(!ModelState.IsValid)
            {
                _logger.LogError($"Department payload is invalid. Validation failed with errors: {ModelState.Select(x=>new {x.Key, x.Value}).ToList().ToString()}");
                return BadRequest(ModelState);
            }
            await _service.UpdateAsync(department);
            return NoContent();
        }
        // POST: api/Department
        [HttpPost]
        public async Task<ActionResult<DepartmentDto>> PostDepartment([FromBody] DepartmentDto department)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Department payload is invalid. Validation failed with errors: {ModelState.Select(x=>new {x.Key, x.Value}).ToList().ToString()}");
                return BadRequest(ModelState);
            }
            await _service.AddAsync(department);
            return CreatedAtAction("GetDepartment", new { id = department.Id }, department);
        }
        // DELETE: api/Department/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DepartmentDto>> DeleteDepartment(int id)
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
