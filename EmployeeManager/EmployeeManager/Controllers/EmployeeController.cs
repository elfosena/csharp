using EmployeeManager.Model;
using EmployeeManager.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManager.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }

        [HttpPost("create")]
        public IActionResult CreateEmployee([FromForm] EmployeeModel model)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var employee = new Employee()
            {
                FullName= model.FullName,  
                Email= model.Email,
                Birthdate= model.Birthdate,
            };

            _employeeService.Create(employee);

            return Ok(employee);
        }

        [HttpPut("update")]
        public IActionResult UpdateEmployee(int id, [FromForm] EmployeeModel model)
        {
            var employee = _employeeService.Get(id);

            if (employee == null)
            {
                return NotFound("Employee with id " + id + " does not exist.");
            }

            employee.Email = model.Email;
            employee.FullName = model.FullName;
            employee.Birthdate = model.Birthdate;

            _employeeService.Update(employee);

            return Ok(employee);
        }

        [HttpPost("delete")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _employeeService.Get(id);

            if (employee != null)
            {
                _employeeService.Delete(employee);
                return Ok("Employee with id " + id + " deleted");
            }

            return NotFound("Employee with id " + id + " does not exist.");
        }

        [HttpGet("get")]
        public IActionResult GetEmployee(int id)
        {
            var employee = _employeeService.Get(id);
            if (employee == null)
            {
                return NotFound("Employee with id " + id + " does not exist.");
            }
            return Ok(employee);
        }

        [HttpGet("getall")]
        public IActionResult GetAllEmployees()
        {
            var employees = _employeeService.GetAll();

            return Ok(employees);
        }
    }
}
