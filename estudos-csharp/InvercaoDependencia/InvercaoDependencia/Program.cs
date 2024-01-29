using Microsoft.Extensions.DependencyInjection;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        IServiceCollection services = new ServiceCollection();

        Startup startup = new Startup();
        startup.ConfigureServices(services);

        IServiceProvider serviceProvider = services.BuildServiceProvider();

        // entry to run app
        serviceProvider.GetService<Runner>().Run();
    }
}