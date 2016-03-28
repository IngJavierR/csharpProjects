using System.Data.Linq.Mapping;

namespace SQLiteAdmin.Db.Entities
{
    [Table(Name = "employee")]
    public class Employee
    {
        [Column(Name = "empid", IsPrimaryKey = true, IsDbGenerated = true)]
        public int Empid { get; set; }
        [Column(Name = "name")]
        public string Name { get; set; }
        [Column(Name = "title")]
        public string Title { get; set; }
    }
}
