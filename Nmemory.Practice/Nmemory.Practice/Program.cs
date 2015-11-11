using System;
using System.Linq;
using NMemory;
using NMemory.Tables;

namespace Nmemory.Practice
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Group Grupo { get; set; }
    }

    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class MyDataBase : Database
    {
        public MyDataBase()
        {
            var peopleTable = Tables.Create<Person, int>(p => p.Id, null);

            People = peopleTable;
        }

        public ITable<Person> People { get; private set; }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Start");
            var db = new MyDataBase();
            db.People.Insert(new Person
            {
                Id = 1,
                Grupo = new Group { Id = 2,Name = "Grupo2"},
                Name = "Javier"
            });

            var q = (from p in db.People select p).FirstOrDefault();

            if (q != null)
            {
                Console.WriteLine("Id: " + q.Id);
                Console.WriteLine("GroupId: " + q.Grupo.Id);
                Console.WriteLine("GroupName: " + q.Grupo.Name);
                Console.WriteLine("Name: " + q.Name);
            }
            else
            {
                Console.WriteLine("Null");
            }

            Console.Read();
        }
    }
}
