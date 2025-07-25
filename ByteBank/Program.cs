using ByteBank;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("------------- Boas Vindas ao seu banco, ByteBank! -------------\n");

        //---------------Conta 1--------------------
        ContaCorrente conta1 = new ContaCorrente();
        conta1.titular = "Andre Bessa";
        conta1.conta = "10123-x";
        conta1.numero_agencia = 777;
        conta1.nome_agencia = "agencia central";
        conta1.saldo = 200;
        //Console.WriteLine($"Títular: {conta1.titular}");
        //Console.WriteLine($"Conta: {conta1.conta}");
        //Console.WriteLine($"Número da Agencia: {conta1.numero_agencia}");
        //Console.WriteLine($"Nome da Agencia: {conta1.nome_agencia}");
        //Console.WriteLine($"Saldo: {conta1.saldo}\n");

        //---------------Conta 2--------------------
        ContaCorrente conta2 = new ContaCorrente();
        conta2.titular = "Dereck";
        conta2.conta = "10105-X";
        conta2.numero_agencia = 26;
        conta2.nome_agencia = "Agencia Central";
        conta2.saldo = 550;
        //Console.WriteLine($"Títular: {conta2.titular}");
        //Console.WriteLine($"Conta: {conta2.conta}");
        //Console.WriteLine($"Núumero da Agencia: {conta2.numero_agencia}");
        //Console.WriteLine($"Nome da Agencia: {conta2.nome_agencia}");
        //Console.WriteLine($"Saldo: {conta2.saldo}\n");

        //---------------Conta 3--------------------
        //ContaCorrente conta3 = new ContaCorrente();
        //Console.WriteLine($"Títular: {conta3.titular}");
        //Console.WriteLine($"Conta: {conta3.conta}");
        //Console.WriteLine($"Núumero da Agencia: {conta3.numero_agencia}");
        //Console.WriteLine($"Nome da Agencia: {conta3.nome_agencia}");
        //Console.WriteLine($"Saldo: {conta3.saldo}\n");


        //Console.WriteLine($"Saldo do Dereck pré-saque: {conta2.saldo}");
        //conta2.Sacar(550);
        //Console.WriteLine($"Saldo do  Dereck pós-saque: {conta2.saldo}");
        //conta2.Sacar(550);

        Console.WriteLine($"Saldo do Dereck pré-transferencia: {conta2.saldo}");
        Console.WriteLine($"Saldo do  André pré-transferencia: {conta1.saldo}\n\n");
        bool transferencia = conta1.Transferir(50, conta2);
        Console.WriteLine($"Saldo do Dereck pós-transferencia: {conta2.saldo}");
        Console.WriteLine($"Saldo do  André pós-transferencia: {conta1.saldo}");





        //double saldo = 100;
        //double saldo2 = conta1.saldo;

        //Console.WriteLine(saldo == conta1.saldo);
        //Console.WriteLine(saldo == saldo2);

        Console.ReadKey();
    }
}
