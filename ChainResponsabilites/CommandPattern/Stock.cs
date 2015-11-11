using System;

namespace CommandPattern
{
    public class Stock
    {
        private string _name = "ABC";
        private int _quantity = 10;

        public void Buy()
        {
            Console.WriteLine("Stock Name: [{0}], Quantity: [{1}] Bought", _name, _quantity);
        }

        public void Sell()
        {
            Console.WriteLine("Stock Name: [{0}], Quantity: [{1}] Sell", _name, _quantity);
        }
    }
}
