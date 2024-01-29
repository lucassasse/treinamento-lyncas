namespace RoletaDeletadoraDePasta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(1, 7);
            string path = @"C:\Users\Lyncas\Desktop\excluir";

            Console.WriteLine("ROLETA RUSSA DE EXCLUSÃO DE PASTA!");
            Console.WriteLine("-------------------------------------");
            
            Console.Write("Digite um numero entre 1 e 6: ");
            int n = int.Parse(Console.ReadLine());
            
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"O número sorteado foi: {randomNumber}");
            Console.WriteLine();

            if (n == randomNumber)
            {
                Console.WriteLine("Lamento, mas a pasta System32 será excluída em 3...");
                Thread.Sleep(1000);
                Console.WriteLine("2...");
                Thread.Sleep(1000);
                Console.WriteLine("1...");
                Thread.Sleep(1000);
                Console.Write("");
                Directory.Delete(path, true);
                Console.WriteLine("Pasta deletada com sucesso!");
            }
            else
            {
                Console.WriteLine("Foi por pouco em...");
            }
        }
    }
}
