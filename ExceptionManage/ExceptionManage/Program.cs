using System;
using System.Net;

namespace ExceptionManage
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Start");
                throw new MizuhoException("Error general", 101);

            }
            catch (MizuhoException ex)
            {
                Console.WriteLine("Message: " + ex.Message);
                Console.WriteLine("Code: " + ex.Code);
                Console.WriteLine("Inner: " + ex.InnerException);
            }

            try
            {
                Console.WriteLine("Start2");
                throw new Exception("Error general Exc");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Message: " + ex.Message);
                Console.WriteLine("Inner: " + ex.InnerException);
            }
            Console.Read();
        }
    }
}
