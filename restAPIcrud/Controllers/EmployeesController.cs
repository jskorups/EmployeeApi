using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using restAPIcrud.EmployeeData;
using restAPIcrud.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restAPIcrud.Controllers
{
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        // get all
        // get single
        // delete employee
        // add employee

        private IEmployeeData _employeedate;

        public EmployeesController(IEmployeeData employeeData)
        {
            _employeedate = employeeData;
        }

        [HttpGet]
        [Route ("api/[controller]")]
        public IActionResult GetEmployees()
        {
            return Ok(_employeedate.GetEmployees());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetEmployee(Guid id)
        {
            var employee = _employeedate.GetEmployee(id);

            if (employee != null )
            {
                return Ok(employee);
            }

            return NotFound($"Employee with id = {id} was not found");
        }

        // add employee
        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddEmployee(Employee  employee)
        {
            _employeedate.AddEmployee(employee);
              return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/"+ employee.id, employee) ;
        }

        // add employee
        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = _employeedate.GetEmployee(id);
            if (employee != null)
            {
                _employeedate.DeleteEmployee(employee);
                return Ok(); // status OK
            }
            return NotFound("Not found");
        }

        [HttpPut]
        [Route("api/[controller]/{id}")]
        public IActionResult EditEmployee(Guid id, Employee employee)
        {
            var existingEmployee = _employeedate.GetEmployee(id);
            if (existingEmployee != null)
            {
                employee.id = existingEmployee.id;
                _employeedate.EditEmployee(employee);
                return Ok(employee); // status OK

            }
            return NotFound("Not found");
        }
    }
}
