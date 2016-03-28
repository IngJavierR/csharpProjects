using System;

namespace CommandActions
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Inicia Programa");

            Console.WriteLine("1.- Prueba1");
            Console.WriteLine("2.- Prueba2");
            Console.WriteLine("3.- Prueba3");
            var selection = "";
            Console.CancelKeyPress += (sender, args) =>
            {
                Console.WriteLine("A donde vas?");
            };
            while (selection != "4")
            {
                selection = Console.ReadLine();
                switch (selection)
                {
                    case "1":
                        Console.WriteLine("Esto es el menu 1");
                        break;
                    case "2":
                        Console.WriteLine("Esto es el menu 2");
                        break;
                    case "3":
                        Console.WriteLine("Esto es el menu 3");
                        break;
                }
            }
            Console.WriteLine("Sali del while");
            Console.ReadLine();
        }
    }
}
