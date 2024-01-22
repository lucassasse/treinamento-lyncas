using GerenciadorContaBancariaComExcecoes.Entities.Exceptions;

namespace GerenciadorContaBancariaComExcecoes.Entities
{
    internal class Account
    {
        public int Number { get; set; }
        public string Holder { get; set; }
        public double Balance { get; set; }
        public double WithdrawLimit { get; set; }

        public Account(int number, string holder, double balance, double withdrawLimit)
        {
            Number = number;
            Holder = holder;
            Balance = balance;
            WithdrawLimit = withdrawLimit;
        }

        public void Deposit(double amount)
        {
            if (amount < 0)
            {
                throw new DomainException("O valor do depósito não pode ser menor ou igual a zero.");
            }
            else
            {
                Balance += amount;
            }
        }

        public void Withdraw(double amount)
        {
            if (amount < 0 || amount > Balance)
            {
                throw new DomainException("O valor do saque deve ser maior que zero e menor ou igual ao saldo disponível.");
            }
            if (amount > WithdrawLimit)
            {
                throw new DomainException("O valor solicitado ultrapassou o valor limite de saque.");
            }
            Balance -= amount;
        }
    }
}
