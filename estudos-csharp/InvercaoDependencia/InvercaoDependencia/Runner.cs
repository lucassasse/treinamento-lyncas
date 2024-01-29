using InvercaoDependencia.Interfaces.Services;
using InvercaoDependencia.Repository;
using InvercaoDependencia.Services;

public class Runner
{
    private readonly IPedidoService _pedidoService;

    public Runner(IPedidoService pedidoService)
    {
        _pedidoService = pedidoService;
    }

    public void Run()
    {        
        var pedido = _pedidoService.BuscarPedido();

        Console.WriteLine("----------------------------------");
        Console.WriteLine("      Conteúdo do pedido");
        Console.WriteLine("----------------------------------");
        Console.WriteLine(pedido);
        Console.WriteLine("----------------------------------");
    }
}