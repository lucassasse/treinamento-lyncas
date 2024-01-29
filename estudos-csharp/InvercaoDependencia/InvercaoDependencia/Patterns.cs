using System;

// Estado e Comportamento
public class Pessoa
{
    // Estado
    public string Nome { get; set; }
    public int Idade { get; set; }

    // Comportamento
    public void Apresentar()
    {
        Console.WriteLine($"Olá, meu nome é {Nome} e tenho {Idade} anos.");
    }
}

// Herança
public class Aluno : Pessoa
{
    public string Matricula { get; set; }
}

// Abstração
public abstract class Animal
{
    // Método abstrato (sem implementação)
    public abstract void EmitirSom();
}

public class Cachorro : Animal
{
    // Implementação do método abstrato
    public override void EmitirSom()
    {
        Console.WriteLine("Au Au!");
    }
}

// Polimorfismo
public class Gato : Animal
{
    // Implementação do método abstrato de forma diferente
    public override void EmitirSom()
    {
        Console.WriteLine("Miau!");
    }
}

// Encapsulamento
public class ContaBancaria
{
    // Propriedades privadas
    private double _saldo;

    // Propriedade pública encapsulada
    public double Saldo
    {
        get { return _saldo; }
        set { _saldo = value; }
    }

    // Método encapsulado
    public void Depositar(double valor)
    {
        _saldo += valor;
    }
}

// Interface x Implementação
public interface IEnviavel
{
    void Enviar();
}

public class Email : IEnviavel
{
    public void Enviar()
    {
        Console.WriteLine("Enviando e-mail...");
    }
}

// Herança x Composição
public class Carro
{
    public void Ligando()
    {
        Console.WriteLine("Carro ligado.");
    }
}

public class CarroComArCondicionado : Carro
{
    private readonly ArCondicionado _arCondicionado;

    public CarroComArCondicionado()
    {
        _arCondicionado = new ArCondicionado();
    }

    public void AtivarArCondicionado()
    {
        _arCondicionado.Ativar();
    }
}

public class ArCondicionado
{
    public void Ativar()
    {
        Console.WriteLine("Ar condicionado ativado.");
    }
}

class Executar
{
    static void run()
    {
        // Estado e Comportamento
        Pessoa pessoa = new Pessoa { Nome = "Ana", Idade = 25 };
        pessoa.Apresentar();

        // Herança
        Aluno aluno = new Aluno { Nome = "Carlos", Idade = 20, Matricula = "12345" };
        aluno.Apresentar();

        // Abstração e Polimorfismo
        Animal cachorro = new Cachorro();
        Animal gato = new Gato();

        cachorro.EmitirSom();
        gato.EmitirSom();

        // Encapsulamento
        ContaBancaria conta = new ContaBancaria();
        conta.Depositar(1000);
        Console.WriteLine($"Saldo atual: {conta.Saldo}");

        // Interface x Implementação
        IEnviavel email = new Email();
        email.Enviar();

        // Herança x Composição
        CarroComArCondicionado carroComAr = new CarroComArCondicionado();
        carroComAr.Ligando();
        carroComAr.AtivarArCondicionado();
    }
}
