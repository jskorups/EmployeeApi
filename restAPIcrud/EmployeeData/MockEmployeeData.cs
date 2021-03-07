using restAPIcrud.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restAPIcrud.EmployeeData
{
    public class MockEmployeeData : IEmployeeData
    {

        private List<Employee> employees = new List<Employee>()
        {
            new Employee()
            {
                id = Guid.NewGuid(),
                Name = "Jan Błachowicz"
            },
              new Employee()
            {
                id = Guid.NewGuid(),
                Name = "Jan Kowalski"
            },
                new Employee()
            {
                id = Guid.NewGuid(),
                Name = "Marcin Nowak"
            }
        };

        

        public Employee AddEmployee(Employee employee)
        {
            employee.id = Guid.NewGuid();
            employees.Add(employee);
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {

            employees.Remove(employee);
        }

        public Employee EditEmployee(Employee employee)
        {
            var emp = GetEmployee(employee.id);
            emp.Name = employee.Name;
            return emp;
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }

        public Employee GetEmployee(Guid id)
        {
            return employees.SingleOrDefault(x => x.id == id);
        }
    }
}
