using GerenciamentoContribuintes.Entities;
using System.Globalization;

namespace GerenciamentoContribuintes {
    internal class Program {
        static void Main(string[] args) {
            List<TaxPayer> list = new List<TaxPayer>();

            Console.Write("Enter the number of tax payers: ");
            int quantityPayers = int.Parse(Console.ReadLine());

            for (int i = 1; i <= quantityPayers; i++) {
                Console.WriteLine($"Tax payer #{i} data:");
                Console.Write("Individual or Company (i/c)? ");
                char typePayer = char.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Anual income: ");
                double anualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (typePayer == 'i') {
                    Console.Write("Health expenditures: ");
                    double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    list.Add(new Individual(name, anualIncome, value));
                } else {
                    Console.Write("Number of employees: ");
                    int value = int.Parse(Console.ReadLine());
                    list.Add(new Company(name, anualIncome, value));
                }
            }

            double sum = 0.0;
            Console.WriteLine();
            Console.WriteLine("TAXES PAID:");
            foreach (TaxPayer taxPayer in list) {
                Console.WriteLine(taxPayer.Name + ": R$" + taxPayer.Tax().ToString("F2", CultureInfo.InvariantCulture));
                sum += taxPayer.Tax();
            }

            Console.WriteLine();
            Console.WriteLine("TOTAL TAXES: " + sum.ToString("F2"), CultureInfo.InvariantCulture);
        }
    }
}
