public class GerenciadorTriagem
{
    private Queue<Paciente> filaTriagem = new();

    public void AdicionarPaciente(Paciente paciente)
    {
        filaTriagem.Enqueue(paciente);
    }

    public Paciente AtenderPaciente()
    {
        if (filaTriagem.Count == 0)
            return null;

        var paciente = filaTriagem.Dequeue();

        // Lógica de triagem
        if (paciente.Temperatura >= 39 || paciente.Oxigenacao <= 92)
            paciente.Prioridade = "Vermelho";
        else if (paciente.Temperatura >= 37.5 || paciente.PressaoArterial >= 14)
            paciente.Prioridade = "Amarelo";
        else
            paciente.Prioridade = "Verde";

        return paciente;
    }
}
