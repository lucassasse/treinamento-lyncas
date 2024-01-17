namespace GerenciamentoPedidos {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("Enter client data");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            string date = Console.ReadLine();

            Console.WriteLine("Enter order data");
            Console.Write("Status: ");
            string status = Console.ReadLine();

            Console.Write("How many items to this order?: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++) {
                Console.WriteLine($"Enter #{i} item data");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();
                Console.Write("Product price: ");
                double productPrice = double.Parse(Console.ReadLine());
                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("ORDER SUMARY");

            Console.WriteLine("Order items");
        }
    }
}
