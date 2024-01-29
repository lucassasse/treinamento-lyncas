using InvercaoDependencia.Interfaces.Repositories;
using InvercaoDependencia.Interfaces.Services;

namespace InvercaoDependencia.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IProdutoService _produtoService;
        private readonly IClienteService _clienteService;

        public PedidoService(IPedidoRepository pedidoRepository, IProdutoService produtoService, IClienteService clienteService)
        {
            _pedidoRepository = pedidoRepository;
            _produtoService = produtoService;
            _clienteService = clienteService;
        }

        public string BuscarPedido()
        {
            var codigoPedido = _pedidoRepository.Get();
            var produto = _produtoService.BuscarProduto();
            var cliente = _clienteService.BuscarCliente();

            return $"O pedido {codigoPedido} do item {produto} foi realizado para o cliente {cliente}";
        }
    }
}
