﻿namespace CommandPattern
{
    public class BuyStock : IOrder
    {
        private readonly Stock _abcStock;

        public BuyStock(Stock abcStock)
        {
            _abcStock = abcStock;
        }

        public void Execute()
        {
            _abcStock.Buy();
        }
    }
}
