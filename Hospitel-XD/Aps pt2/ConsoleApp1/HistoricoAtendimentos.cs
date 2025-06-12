using System;
using System.Collections.Generic;

public class HistoricoAtendimentos
{
    private List<Paciente> pacientesAtendidos = new List<Paciente>();

    public void AdicionarPacienteAtendido(Paciente paciente)
    {
        pacientesAtendidos.Add(paciente);
    }

    public void ExibirHistoricoDetalhado()
    {
        Console.WriteLine("\n--- Histórico de Pacientes Atendidos ---");
        if (pacientesAtendidos.Count == 0)
        {
            Console.WriteLine("Nenhum paciente foi atendido ainda.");
            return;
        }

        foreach (var paciente in pacientesAtendidos)
        {
            Console.WriteLine(paciente);
        }
    }
}
