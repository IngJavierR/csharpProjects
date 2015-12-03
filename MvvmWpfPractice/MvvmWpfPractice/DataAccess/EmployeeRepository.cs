using System.Collections.Generic;
using MvvmWpfPractice.Model;

namespace MvvmWpfPractice.DataAccess
{
    public class EmployeeRepository
    {
        private readonly List<Employee> _employees;

        public EmployeeRepository()
        {
            if (_employees == null)
            {
                _employees = new List<Employee>();
            }
            _employees.Add(Employee.CreatEmployee("Jimena", "Rodriguez"));
            _employees.Add(Employee.CreatEmployee("Jazmin", "Rodriguez"));
            _employees.Add(Employee.CreatEmployee("Javier", "Rodriguez"));
        }

        public List<Employee> GetEmployees()
        {
            return _employees;
        }
    }
}
