using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    public class ContaCorrente
    {
        public string titular;
        public string conta;
        public int numero_agencia;
        public string nome_agencia;
        public double saldo;

        public bool Sacar (double valor)
        {
            if (saldo < valor)
            {
                return false;
            }
            if (valor < 0)
            {
                Console.WriteLine("Saldo insuficiente na conta para efetuar essa compra");
                return false;
            }
            if (saldo >= valor)
            {
                saldo = saldo - valor;
                return true;
            }
            else
            {
                Console.WriteLine("ERRO!");
                return false;
            }
            saldo = saldo + valor;
        }


        public bool Transferir(double valor, ContaCorrente destino)
        {
            if (saldo < valor)
            {
                return false;
            }
            if (valor < 0)
            {
                return false;
            }
            else
            {
                saldo = saldo - valor;
                destino.saldo = destino.saldo + valor;
                return true;
            }
        }
    }
}
