using InvercaoDependencia.Interfaces.Repositories;

namespace InvercaoDependencia.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        public ClienteRepository() { }

        public string Get()
        {
            return "João";
        }
    }
}
