using AluguelCarros.Entities;
using AluguelCarros.Services;
using System.Globalization;

namespace AluguelCarros
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter rental data");
            Console.Write("Car model: ");
            string vehicleModel = Console.ReadLine();
            Console.Write("Pickup (dd/MM/yyyy hh:mm): ");
            DateTime start = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            Console.Write("Return (dd/MM/yyyy hh:mm): ");
            DateTime finish = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            Console.Write("Enter price per hour: ");
            double priceHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter price per day: ");
            double priceDay = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            CarRental carRentar = new CarRental(start, finish, new Vehicle(vehicleModel));

            RentalService rentalService = new RentalService(priceHour, priceDay, new BrazilTaxService());

            rentalService.ProcessInvoice(carRentar);

            Console.WriteLine();
            Console.WriteLine("INVOICE: ");
            Console.WriteLine(carRentar.Invoice);
        }
    }
}
