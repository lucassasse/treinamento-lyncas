using InvercaoDependencia.Interfaces.Repositories;

namespace InvercaoDependencia.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        public PedidoRepository() { }

        public string Get()
        {
            return "123";
        }
    }
}
