using System;

namespace CommandPattern
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Command Patter [Start]");

            var stock = new Stock();

            var sellObject = new SellStock(stock);
            var buyObject = new BuyStock(stock);

            var broker = new Broker();
            broker.TakeOrder(sellObject);
            broker.TakeOrder(buyObject);
            broker.TakeOrder(buyObject);
            broker.TakeOrder(sellObject);

            broker.PlaceOrder();

            Console.WriteLine("Command Patter [End]");
            Console.Read();
        }
    }
}
