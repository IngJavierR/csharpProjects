using System;

namespace ChainResponsabilites
{
    class Program
    {
        static void Main()
        {
            Handler st1 = new ResponsibilityOne();
            Handler st2 = new ResponsibilityTwo();
            st1.SetSuccessor(st2);

            Console.WriteLine("Prueba 1");
            st1.HandlerRequest(1);

            Console.WriteLine("Prueba 2");
            st1.HandlerRequest(2);

            Console.WriteLine("Prueba 3");
            st1.HandlerRequest(3);

            Console.ReadLine();
        }
    }
}
