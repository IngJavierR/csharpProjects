using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FirstProjectPractice
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Inicio");

            AccessWebAsync().ContinueWith(x => LlamadaFin());

            Console.WriteLine("Fin");
            Console.ReadLine();
        }

        private static void LlamadaFin()
        {
            Console.WriteLine("LlamadaFin");
        }

        private static async Task<int> AccessWebAsync()
        {
            HttpClient client = new HttpClient();

            Task<string> getStringTask = client.GetStringAsync("http://msdn.microsoft.com");

            DoIndependentWork();

            var resultado = await getStringTask;

            return resultado.Length;
        }

        private static void DoIndependentWork()
        {
            Console.WriteLine("Doing something");
        }
    }
}
