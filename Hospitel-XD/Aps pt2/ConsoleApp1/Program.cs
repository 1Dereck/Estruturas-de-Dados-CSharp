using System;

namespace ProjetoHospital
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var gerenciadorTriagem = new GerenciadorTriagem();
            var filaAtendimento = new FilaAtendimentoPrioridade();
            var clinico = new ClinicoGeral();
            var historico = new HistoricoAtendimentos();

            void EscreverTitulo(string texto, ConsoleColor corTexto = ConsoleColor.Cyan)
            {
                Console.ForegroundColor = corTexto;
                Console.WriteLine($"\n---- {texto} ---- ");
                Console.ResetColor();
            }

            bool executando = true;
            while (executando)
            {
                Console.Clear();
                EscreverTitulo("\r\n██╗  ██╗ ██████╗ ███████╗██████╗ ██╗████████╗ █████╗ ██╗     \r\n██║  ██║██╔═══██╗██╔════╝██╔══██╗██║╚══██╔══╝██╔══██╗██║     \r\n███████║██║   ██║███████╗██████╔╝██║   ██║   ███████║██║     \r\n██╔══██║██║   ██║╚════██║██╔═══╝ ██║   ██║   ██╔══██║██║     \r\n██║  ██║╚██████╔╝███████║██║     ██║   ██║   ██║  ██║███████╗\r\n╚═╝  ╚═╝ ╚═════╝ ╚══════╝╚═╝     ╚═╝   ╚═╝   ╚═╝  ╚═╝╚══════╝\r\n                                                             \r\n", ConsoleColor.Red);

                Console.WriteLine("\n1. Adicionar Paciente");
                Console.WriteLine("2. Iniciar Triagem");
                Console.WriteLine("3. Exibir Fila de Atendimento");
                Console.WriteLine("4. Iniciar Atendimento Clínico");
                Console.WriteLine("5. Exibir Histórico de Atendimentos");
                Console.WriteLine("6. Sair");
                Console.Write("\nEscolha uma opção: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        string continuar;
                        do
                        {
                            Console.Clear();
                            AdicionarPaciente();

                            Console.Write("\nDeseja incluir mais pacientes? (s/n): ");
                            continuar = Console.ReadLine()?.Trim().ToLower();

                        } while (continuar == "s");
                        break;
                    case "2":
                        Console.Clear();
                        IniciarTriagem();
                        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        filaAtendimento.ExibirFila();
                        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.Clear();
                        IniciarAtendimento();
                        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                        Console.ReadKey();
                        break;
                    case "5":
                        Console.Clear();
                        historico.ExibirHistoricoDetalhado();
                        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                        Console.ReadKey();
                        break;

                    case "6":
                        executando = false;
                        Console.WriteLine("Finalizando sessão...");
                        Thread.Sleep(2000);
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }

            void AdicionarPaciente()
            {
                EscreverTitulo("Nova Chegada de Paciente", ConsoleColor.Yellow);

                Console.Write("Nome: ");
                string nome = Console.ReadLine()!;

                Console.Write("Idade: ");
                if (!int.TryParse(Console.ReadLine(), out int idade))
                {
                    Console.WriteLine("Idade inválida.");
                    return;
                }

                Console.Write("Pressão arterial (ex: 12.8): ");
                if (!double.TryParse(Console.ReadLine(), out double pressao))
                {
                    Console.WriteLine("Pressão inválida.");
                    return;
                }

                Console.Write("Temperatura (ex: 37.5): ");
                if (!double.TryParse(Console.ReadLine(), out double temperatura))
                {
                    Console.WriteLine("Temperatura inválida.");
                    return;
                }

                Console.Write("Oxigenação (ex: 95): ");
                if (!int.TryParse(Console.ReadLine(), out int oxigenacao))
                {
                    Console.WriteLine("Oxigenação inválida.");
                    return;
                }

                var paciente = new Paciente(nome, idade, pressao, temperatura, oxigenacao);
                gerenciadorTriagem.AdicionarPaciente(paciente);
            }

            void IniciarTriagem()
            {
                EscreverTitulo("Iniciando Triagem", ConsoleColor.Cyan);
                Paciente paciente;
                while ((paciente = gerenciadorTriagem.AtenderPaciente()) != null)
                {
                    filaAtendimento.AdicionarPaciente(paciente);
                }
            }


            void IniciarAtendimento()
            {
                EscreverTitulo("Iniciando Atendimento", ConsoleColor.Magenta);
                Paciente paciente;
                while ((paciente = filaAtendimento.AtenderProximoPaciente()) != null)
                {
                    clinico.Atender(paciente);
                    historico.AdicionarPacienteAtendido(paciente);
                }
            }
        }
    }
}
