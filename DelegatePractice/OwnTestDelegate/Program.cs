using System;

namespace OwnTestDelegate
{
    public class DelegateClass
    {
        public delegate void MyDelegate(int a, int b);

        public void Suma(int a, int b)
        {
            Console.WriteLine("Suma: " + (a + b));
        }

        public void Resta(int a, int b)
        {
            Console.WriteLine("Resta: " + (a - b));
        }

        public void Division(int a, int b)
        {
            Console.WriteLine("Division: " + (a / b));
        }

        public void Multiplicacion(int a, int b)
        {
            Console.WriteLine("Multiplicacion: " + (a * b));
        }
    }

    class Program
    {
        static void Main()
        {
            DelegateClass operaciones = new DelegateClass();
            DelegateClass.MyDelegate exec = operaciones.Suma;
            exec(15, 5);
            exec = operaciones.Resta;
            exec(15, 5);
            exec = operaciones.Multiplicacion;
            exec(15, 5);
            exec = operaciones.Division;
            exec(15, 5);

            Console.Read();
        }
    }
}
