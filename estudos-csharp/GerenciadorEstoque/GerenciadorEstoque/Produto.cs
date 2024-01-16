using System.Globalization;

namespace GerenciadorEstoque
{
    internal class Produto
    {
        //Atributos Públicos e Privados
        private string _nome;

        //Atributos com Propriedades autoimplementadas
        public double Valor { get; private set; }
        public int QuantidadeEmEstoque { get; private set; }

        //Construtores
        public Produto() { }

        public Produto(string nome, double valor) {
            _nome = nome;
            Valor = valor;
        }

        public Produto(string nome, double valor, int quantidadeEmEstoque){
            _nome = nome;
            Valor = valor;
            QuantidadeEmEstoque = quantidadeEmEstoque;
        }

        //Propriedades customizadas
        public string Nome {
            get { return _nome; }
            set {
                if (value != null && value.Length > 1) {
                    _nome = value;
                }
            }
        }

        //Outros métodos da classe
        public double ValorTotalEmEstoque()
        {
            return Valor * QuantidadeEmEstoque;
        }

        public void AdicionarAoEstoque(int quantidade)
        {
            QuantidadeEmEstoque += quantidade;
        }

        public void RemoverDoEstoque(int quantidade)
        {
            QuantidadeEmEstoque += quantidade;
        }

        public override string ToString()
        {
            return "Produto: "
                + _nome
                + ", Valor Unitário R$"
                + Valor.ToString("F2", CultureInfo.InvariantCulture)
                + ", Quantidade em Estoque: "
                + QuantidadeEmEstoque
                + " unidades, Valor Total: R$"
                + ValorTotalEmEstoque().ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
