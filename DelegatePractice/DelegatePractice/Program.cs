using System;

namespace DelegatePractice
{
    internal delegate int MathAction(int num1, int num2);

    class Program
    {
        static void Main()
        {
            MathAction ma = Suma;
            var resultado1 = ma(5, 10);
            Console.WriteLine("Resultado1 = " + resultado1);

            Func<int, int> ma2 = s => s + s;
            var resultado2 = ma2(10);
            Console.WriteLine("Resultado2 = " + resultado2);

            Console.Read();
        }

        static int Suma(int a, int b)
        {
            return a + b;
        }
    }
}
