using InvercaoDependencia.Interfaces.Repositories;
using InvercaoDependencia.Interfaces.Services;
using InvercaoDependencia.Repository;
using InvercaoDependencia.Services;
using Microsoft.Extensions.DependencyInjection;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<Runner>();
        
        services.AddSingleton<IClienteRepository, ClienteRepository>();
        services.AddSingleton<IPedidoRepository, PedidoRepository>();
        services.AddSingleton<IProdutoRepository, ProdutoRepository>();

        services.AddSingleton<IClienteService, ClienteService>();
        services.AddSingleton<IPedidoService, PedidoService>();
        services.AddSingleton<IProdutoService, ProdutoService>();
    }
}