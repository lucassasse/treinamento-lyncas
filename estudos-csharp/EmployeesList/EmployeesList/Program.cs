using System.Globalization;

namespace EmployeesList {
    internal class Program {
        static void Main(string[] args) {
            Console.Write("How many employees will be registered? ");
            int n = int.Parse(Console.ReadLine());

            List<Employee> list = new List<Employee>();

            for (int i = 0; i < n; i++) {
                Console.Write("Employee Id: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Employee Name: ");
                string name = Console.ReadLine();

                Console.Write("Employee Salary: ");
                double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                list.Add(new Employee(id, name, salary));
                Console.WriteLine();
            }

            foreach (Employee obj in list) {
                Console.WriteLine(obj);
            }
            Console.WriteLine();

            Console.Write("Enter the employee id that will have salary increase: ");
            int searchId = int.Parse(Console.ReadLine());
            
            Employee emp = list.Find(x => x.Id == searchId);
            if (emp != null) {
                Console.Write("Enter the percentage: ");
                double percentageIncrease = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                emp.IncreaseSalary(percentageIncrease);
            } else {
                Console.WriteLine("This Id does not exist!");
            }

            Console.WriteLine();
            Console.WriteLine("Update list of employees:");
            foreach(Employee obj in list) {
                Console.WriteLine(obj);
            }

        }
    }
}
