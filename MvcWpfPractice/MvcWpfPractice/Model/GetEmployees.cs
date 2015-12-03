using System;
using System.Collections.ObjectModel;

namespace MvcWpfPractice.Model
{
    public class GetEmployees : ObservableCollection<Employee>
    {
        public static GetEmployees LoadEmployees()
        {
            GetEmployees employees = new GetEmployees
            {
                new Employee() {Age = 20, Id = 1, Inscripcion = DateTime.Now, Name = "Javier"},
                new Employee() {Age = 25, Id = 2, Inscripcion = DateTime.Now, Name = "Francisco"},
                new Employee() {Age = 30, Id = 3, Inscripcion = DateTime.Now, Name = "Juan"}
            };
            return employees;
        }
    }
}
