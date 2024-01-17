using GerenciamentoPedidos.Entities.Enums;

namespace GerenciamentoPedidos.Entities {
    internal class Order {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order() { }

        public Order(DateTime moment, OrderStatus status, Client client) {
            Status = status;
            Moment = moment;
            Client = client;
        }

        public void AddItem(OrderItem item) {
            Items.Add(item);
        }

        public void RemoveItem(OrderItem item) {
            Items.Remove(item);
        }

        public double Total() {
            double sum = 0.0;
            foreach (OrderItem item in Items) {
                sum += item.SubTotal();
            }
            return sum;
        }

        public override string ToString() {
            return "return";
        }
    }
}
