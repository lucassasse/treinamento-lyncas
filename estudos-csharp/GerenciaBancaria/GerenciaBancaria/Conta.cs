using System;
using System.Globalization;

namespace GerenciaBancaria {
    internal class Conta {
        //Atributos autoimplementados
        public int Numero { get; private set; }
        public string Nome { get; set; }
        public double Saldo { get; private set; }

        //Construtores
        public Conta(int numero, string nome) {
            Numero = numero;
            Nome = nome.Trim();
        }

        public Conta(int numero, string nome, double depositoInicial) : this(numero, nome) {
            Deposito(depositoInicial);
        }

        //Outros métodos da classe
        public string Saque(double saque) {
            if (saque < 0) {
                return "O valor do saque não pode ser menor ou igual a zero.";
            } else if(saque > (Saldo - 5)) {
                return "O valor em conta é insuficiente para realizar este saque.";
            } else {
                Saldo -= saque + 5.0;
                return "Saque realizado com sucesso.";
            }
        }

        public string Deposito(double deposito) {
            if (deposito <= 0) {
                return "O valor a ser depositado deve ser maior que zero.";
            } else {
                Saldo += deposito;
                return "Valor depositado com sucesso";
            }

        }

        public override string ToString() {
            return "Conta: "
                + Numero
                + ", Titular: "
                + Nome
                + ", Saldo: R$"
                + Saldo.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
