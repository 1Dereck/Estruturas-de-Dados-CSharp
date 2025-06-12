using System.Collections.Generic;

public class FilaAtendimentoPrioridade
{
    private Queue<Paciente> filaVermelha = new Queue<Paciente>();
    private Queue<Paciente> filaAmarela = new Queue<Paciente>();
    private Queue<Paciente> filaVerde = new Queue<Paciente>();

    public void AdicionarPaciente(Paciente paciente)
    {
        switch (paciente.Prioridade)
        {
            case "Vermelho":
                filaVermelha.Enqueue(paciente);
                break;
            case "Amarelo":
                filaAmarela.Enqueue(paciente);
                break;
            case "Verde":
                filaVerde.Enqueue(paciente);
                break;
        }
    }

    public Paciente AtenderProximoPaciente()
    {
        if (filaVermelha.Count > 0)
            return filaVermelha.Dequeue();
        else if (filaAmarela.Count > 0)
            return filaAmarela.Dequeue();
        else if (filaVerde.Count > 0)
            return filaVerde.Dequeue();
        else
            return null;
    }

    public void ExibirFila()
    {
        Console.WriteLine("--- Fila de Atendimento ---");

        ExibirPacientesPorPrioridade("Vermelho", ConsoleColor.Red, filaVermelha);
        ExibirPacientesPorPrioridade("Amarelo", ConsoleColor.Yellow, filaAmarela);
        ExibirPacientesPorPrioridade("Verde", ConsoleColor.Green, filaVerde);
    }

    private void ExibirPacientesPorPrioridade(string prioridade, ConsoleColor cor, Queue<Paciente> fila)
    {
        Console.ForegroundColor = cor;
        Console.WriteLine($"\nPrioridade {prioridade.ToUpper()}:");
        Console.ResetColor();

        if (fila.Count == 0)
        {
            Console.WriteLine("  (sem pacientes)");
        }
        else
        {
            foreach (var paciente in fila)
            {
                Console.Write("  Nome: " + paciente.Nome);
                Console.Write(" | Idade: " + paciente.Idade);
                Console.Write(" | PA: " + paciente.PressaoArterial);
                Console.Write(" | Temp: " + paciente.Temperatura);
                Console.Write(" | O2: " + paciente.Oxigenacao);
                Console.Write(" | Prioridade: ");
                Console.ForegroundColor = cor;
                Console.WriteLine(prioridade);
                Console.ResetColor();
            }
        }
    }

}
