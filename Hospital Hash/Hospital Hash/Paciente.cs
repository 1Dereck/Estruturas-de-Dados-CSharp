using System;

namespace SistemaClinicoHash
{
    public class Paciente
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public double Pressao { get; set; }
        public double Temperatura { get; set; }
        public double Oxigenacao { get; set; }
        public string Prioridade { get; private set; }

        public Paciente(string cpf, string nome, double pressao, double temperatura, double oxigenacao)
        {
            CPF = cpf;
            Nome = nome;
            Pressao = pressao;
            Temperatura = temperatura;
            Oxigenacao = oxigenacao;
            Prioridade = ClassificarPrioridade();
        }

        public string ClassificarPrioridade()
        {
            if (Pressao > 18 || Temperatura > 39 || Oxigenacao < 90)
                return "Vermelha";
            else if (Pressao < 11 || Temperatura > 37.5 || Oxigenacao < 95)
                return "Amarela";
            else
                return "Verde";
        }

        public override string ToString()
        {
            return $"CPF: {CPF}\nNome: {Nome}\nPressão: {Pressao}\nTemperatura: {Temperatura}\nOxigenação: {Oxigenacao}\nPrioridade: {Prioridade}";
        }
    }
}
