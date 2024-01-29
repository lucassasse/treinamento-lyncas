using InvercaoDependencia.Interfaces.Repositories;

namespace InvercaoDependencia.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        public ProdutoRepository() { }

        public string Get()
        {
            return "Pão";
        }
    }
}
