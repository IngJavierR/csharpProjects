using System;
using SQLiteAdmin.Db.Entities;

namespace SQLiteAdmin
{
    class Program
    {
        static void Main()
        {
            using (var sqlLite = new SqLiteManager("receive.dat"))
            {
                var toSave = new LogDat()
                {
                    ExpectedSize = 1,
                    FechaOperacion = 20160328,
                    HoraOperacion = 134510,
                    Mensaje = "9,8,7,5,4,4,6,76,8,6,6,4,4,34,45,23,64,56,64,5,55",
                    RealSize = 1,
                    SizeValid = 1,
                    StructureValid = 1,
                    TipoPago = 1
                };
                sqlLite.Save(toSave);
                var resultado = sqlLite.Get<LogDat>();
                resultado.ForEach(x =>
                {
                    Console.WriteLine("Item: {0}", x);
                });    
            }
            Console.ReadLine();
        }
    }
}