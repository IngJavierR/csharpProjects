namespace MvvmWpfPractice.Model
{
    public class Employee
    {
        public static Employee CreatEmployee(string firstName, string lastName)
        {
            return new Employee { FirstName = firstName, LastName = lastName };
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
