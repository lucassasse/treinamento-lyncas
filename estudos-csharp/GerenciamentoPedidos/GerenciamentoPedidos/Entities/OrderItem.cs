using System.Globalization;

namespace GerenciamentoPedidos.Entities {
    internal class OrderItem {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Product Product { get; set; }

        public OrderItem() { }

        public OrderItem(int quantity, double price, Product product) {
            Quantity = quantity;
            Price = price;
            Product = product;
        }

        public double SubTotal() {
            return double.Parse((Quantity * Price).ToString("F2", CultureInfo.InvariantCulture));
        }

        public override string ToString() {
            return Product.Name
                + ", $"
                + Price.ToString("F2", CultureInfo.InvariantCulture)
                + ", Quantity: "
                + Quantity
                + ", Subtotal: $"
                + SubTotal().ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
