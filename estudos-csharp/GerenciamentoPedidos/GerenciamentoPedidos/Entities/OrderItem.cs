using System.Globalization;

namespace GerenciamentoPedidos.Entities {
    internal class OrderItem {
        public int Quantity { get; set; }
        public double Price { get; set; }

        public double SubTotal() {
            return double.Parse((Quantity * Price).ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
