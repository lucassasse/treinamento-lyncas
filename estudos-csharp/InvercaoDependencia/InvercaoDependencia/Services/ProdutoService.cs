using InvercaoDependencia.Interfaces.Repositories;
using InvercaoDependencia.Interfaces.Services;

namespace InvercaoDependencia.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public string BuscarProduto()
        {
            return _produtoRepository.Get();
        }
    }
}
