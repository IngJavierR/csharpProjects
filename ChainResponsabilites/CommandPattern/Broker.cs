using System.Collections.Generic;

namespace CommandPattern
{
    public class Broker
    {
        private readonly List<IOrder> _orderList = new List<IOrder>();

        public void TakeOrder(IOrder order)
        {
            _orderList.Add(order);
        }

        public void PlaceOrder()
        {
            foreach (var order in _orderList)
            {
                order.Execute();
            }
            _orderList.Clear();
        }
    }
}
