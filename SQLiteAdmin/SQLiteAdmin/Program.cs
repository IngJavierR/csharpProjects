using System;
using System.Data.Linq;
using System.Data.SQLite;
using System.Linq;
using SQLiteAdmin.Db.Entities;

namespace SQLiteAdmin
{
    class Program
    {
        static void Main()
        {
            var connection = new SQLiteConnection("Data Source = testDB.db; Version = 3;");
            var context = new DataContext(connection);

            var employees = context.GetTable<Employee>();
            
            foreach (var employee in employees)
            {
                Console.WriteLine("Company: {0} - {1} - {2}",
                    employee.Empid, employee.Name, employee.Title);
            }

            employees.InsertOnSubmit(new Employee
            {
                Empid = 2,
                Name = "Prueba",
                Title = "TitlePrueba"
            });
            context.SubmitChanges();
            

            var employees2 = context.GetTable<Employee>().ToList();

            foreach (var employee in employees2)
            {
                Console.WriteLine("Company: {0} - {1} - {2}",
                    employee.Empid, employee.Name, employee.Title);
            }

            Console.ReadKey();
        }
    }
}
