using HospitalGests.Model;
using HospitalGests.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalGests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Departments>>> GetAllDepartaments()
        {
            return Ok(await _departmentService.GetAll());
        }
        [HttpGet("{department_ID}")]
        public async Task<ActionResult<Departments>> GetDepartment(int department_ID)
        {
            var department = await _departmentService.GetDepartment(department_ID); 
            if (department == null)
            {
                return BadRequest("Department not found");
            }
            return Ok(department);
        }

        [HttpPost]
        public async Task<ActionResult<Departments>> CreateDepartment(string name, string description)
        {
            var department = await _departmentService.CreateDepartment(name, description);  
            if (department == null)
            {
                return BadRequest("Department cannot be created");
            }
            return Ok(department);
        }

        [HttpPut("{department_ID}")]
        public async Task<ActionResult<Departments>> UpdateDepartment(int department_ID, string? name = null, string? description = null)
        {
            var departement = await _departmentService.UpdateDepartment(department_ID, name, description);
            if (departement == null)
            {
                return BadRequest("The Department does not exist");
            }
            return Ok(departement);
        }

        [HttpDelete("{department_ID}")]
        public async Task<ActionResult<Departments>> DeleteDepartment(int department_ID)
        {
            var department = await _departmentService.DeleteDepartment(department_ID);
            if (department == null)
            {
                return BadRequest("The Department does not exist");
            }
            return Ok("Department Deleted");
        }
    }
}
