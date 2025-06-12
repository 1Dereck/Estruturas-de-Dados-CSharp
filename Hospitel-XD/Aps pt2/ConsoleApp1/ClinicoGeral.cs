using System;

public class ClinicoGeral
{
    public void Atender(Paciente paciente)
    {
        Console.WriteLine($"\n👨‍⚕️ Atendendo paciente: {paciente.Nome}...");
        Console.WriteLine("Consulta finalizada.");
    }
}
