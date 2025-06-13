using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_11
{
    public class Veiculo
    {
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }

        public Veiculo(string placa, string modelo, int ano)
        {
            Placa = placa;
            Modelo = modelo;
            Ano = ano;
        }

        public override string ToString()
        {
            return $"Placa: {Placa}, Modelo: {Modelo}, Ano: {Ano}";
        }
    }

}
