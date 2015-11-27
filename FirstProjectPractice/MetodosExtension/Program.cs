using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosExtension
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inicio");
            var payDetail = new PayDetail()
            {
                Apellido = null,
                Nombre = null
            };

            Console.WriteLine("Apellido: " + payDetail.Apellido.ValidateNullOrEmpty());
            Console.WriteLine("Nombre: " + payDetail.Nombre.ValidateNullOrEmpty());
            Console.ReadLine();
        }
    }
}
