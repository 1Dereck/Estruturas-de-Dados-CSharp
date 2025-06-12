public class Paciente
{
    public string Nome { get; set; }
    public int Idade { get; set; }
    public double PressaoArterial { get; set; }
    public double Temperatura { get; set; }
    public int Oxigenacao { get; set; }
    public string Prioridade { get; set; }

    public Paciente(string nome, int idade, double pressao, double temperatura, int oxigenacao)
    {
        Nome = nome;
        Idade = idade;
        PressaoArterial = pressao;
        Temperatura = temperatura;
        Oxigenacao = oxigenacao;
        Prioridade = DefinirPrioridade();
    }

    private string DefinirPrioridade()
    {
        if (Oxigenacao < 90 || Temperatura >= 39 || PressaoArterial < 9)
            return "Vermelho";
        else if ((Oxigenacao >= 90 && Oxigenacao <= 94) || (Temperatura > 37.5 && Temperatura < 39))
            return "Amarelo";
        else
            return "Verde";
    }

    public override string ToString()
    {
        return $"Nome: {Nome} | Idade: {Idade} | PA: {PressaoArterial} | Temp: {Temperatura} | O2: {Oxigenacao} | Prioridade: {Prioridade}";
    }
}
