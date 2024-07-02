using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using WebAPIDBFirstApproach.BAL;
using WebAPIDBFirstApproach.Models;

namespace WebAPIDBFirstApproach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        
private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {

            _employeeRepository = employeeRepository;

        }

        [HttpGet]

        public List<Employee> GetEmployees()

        {

            var employees = _employeeRepository.GetAllEmployees();

            return employees;

        }
        [HttpPost]

        public ActionResult<Employee> CreateProduct(Employee Employee)

        {

            try

            {

                _employeeRepository.AddEmployee(Employee);

                return Ok(new { id = Employee.EmpId });

            }

            catch (Exception ex)

            {

                // Handle exceptions as needed

                return StatusCode(500, $"Internal Server Error: {ex.Message}");

            }

        }

        [HttpPut("{id}")]

        public IActionResult UpdateEmployee(int id, Models.Employee Employee)

        {

            if (id != Employee.EmpId)

            {

                return null;

            }

            try

            {

                _employeeRepository.UpdateEmployee(Employee);

            }

            catch (DbUpdateConcurrencyException)

            {

                throw;

            }

            return Ok(new { Message = "Update successful", UpdatedEmployee = Employee });

        }

        [HttpDelete("{id}")]

        public IActionResult DeleteProduct(int id)

        {

            var Employee = _employeeRepository.GetById(id);

            if (Employee == null)

            {

                return NotFound();

            }

            try

            {

                _employeeRepository.DeleteEmployee(Employee);

            }

            catch (Exception ex)

            {

                // Handle exceptions as needed

                return StatusCode(500, $"Internal Server Error: {ex.Message}");

            }

            return NoContent();
        }
    }
}
