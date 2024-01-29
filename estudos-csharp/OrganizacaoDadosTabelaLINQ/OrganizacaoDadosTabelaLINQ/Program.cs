using OrganizacaoDadosTabelaLINQ.Entities;
using System.Globalization;

namespace OrganizacaoDadosTabelaLINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Lyncas\Desktop\estudos-csharp\OrganizacaoDadosTabelaLINQ\list.txt";
            Console.WriteLine($"Full file path: {path}");
            Console.Write("Enter salary: ");
            double minSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            List<Employee> list = new List<Employee>();

            using(StreamReader sr = File.OpenText(path))
            {
                while(!sr.EndOfStream)
                {
                    string[] fields = sr.ReadLine().Split(',');
                    string name = fields[0];
                    string email = fields[1];
                    double salary = double.Parse(fields[2], CultureInfo.InvariantCulture);
                    list.Add(new Employee(name, email, salary));
                }

                var emails = list.Where(obj => obj.Salary > minSalary).OrderBy(obj => obj.Email).Select(obj => obj.Email);
                Console.WriteLine($"Email of people whose salary is more than R${minSalary.ToString("F2", CultureInfo.InvariantCulture)}");
                foreach(string email in emails)
                {
                    Console.WriteLine(email);
                }

                var sum = list.Where(obj => obj.Name[0] == 'M').Sum(obj => obj.Salary);
                Console.WriteLine($"Sum of salary of people whose name starts with 'M': {sum.ToString("F2", CultureInfo.InvariantCulture)}");
            }

            
        }
    }
}
