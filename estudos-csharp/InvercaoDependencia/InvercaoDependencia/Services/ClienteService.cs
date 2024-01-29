using InvercaoDependencia.Interfaces.Repositories;
using InvercaoDependencia.Interfaces.Services;

namespace InvercaoDependencia.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public string BuscarCliente()
        {
            return _clienteRepository.Get();
        }
    }
}
