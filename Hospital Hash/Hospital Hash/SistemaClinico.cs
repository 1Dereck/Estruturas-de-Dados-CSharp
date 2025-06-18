using System;

namespace SistemaClinicoHash
{
    public class SistemaClinico
    {
        private TabelaHash tabela = new();
        private Queue<Paciente> filaTriagem = new();
        private Stack<Paciente> historico = new();

        public void Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA CLÍNICO ===");
                Console.WriteLine("1 - Cadastrar Paciente");
                Console.WriteLine("2 - Buscar Paciente");
                Console.WriteLine("3 - Atualizar Dados Clínicos");
                Console.WriteLine("4 - Remover Paciente");
                Console.WriteLine("5 - Mostrar Tabela Hash");
                Console.WriteLine("6 - Simular Atendimento");
                Console.WriteLine("7 - Ver Histórico de Atendimento");
                Console.WriteLine("0 - Sair\n");
                Console.Write("Escolha: ");
                string op = Console.ReadLine();

                switch (op)
                {
                    case "1": Cadastrar(); break;
                    case "2": Buscar(); break;
                    case "3": Atualizar(); break;
                    case "4": Remover(); break;
                    case "5": tabela.ExibirTabela(); Pause(); break;
                    case "6": Atender(); break;
                    case "7": Historico(); break;
                    case "0": return;
                    default: Console.WriteLine("Opção inválida"); break;
                }
            }
        }

        private void Cadastrar()
        {
            Console.Write("CPF: ");
            string cpf = Console.ReadLine();
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Pressão Arterial: ");
            double pa = double.Parse(Console.ReadLine());
            Console.Write("Temperatura: ");
            double temp = double.Parse(Console.ReadLine());
            Console.Write("Oxigenação: ");
            double ox = double.Parse(Console.ReadLine());

            Paciente paciente = new(cpf, nome, pa, temp, ox);
            tabela.Inserir(paciente);
            filaTriagem.Enqueue(paciente);
            Console.WriteLine("Paciente cadastrado!");
            Pause();
        }

        private void Buscar()
        {
            Console.Write("CPF: ");
            var p = tabela.Buscar(Console.ReadLine());
            Console.WriteLine(p != null ? p.ToString() : "Paciente não encontrado.");
            Pause();
        }

        private void Atualizar()
        {
            Console.Write("CPF: ");
            string cpf = Console.ReadLine();
            Console.Write("Nova Pressão: ");
            double pa = double.Parse(Console.ReadLine());
            Console.Write("Nova Temperatura: ");
            double temp = double.Parse(Console.ReadLine());
            Console.Write("Nova Oxigenação: ");
            double ox = double.Parse(Console.ReadLine());

            if (tabela.Atualizar(cpf, pa, temp, ox))
                Console.WriteLine("Atualizado com sucesso!");
            else
                Console.WriteLine("Paciente não encontrado.");
            Pause();
        }

        private void Remover()
        {
            Console.Write("CPF: ");
            if (tabela.Remover(Console.ReadLine()))
                Console.WriteLine("Removido com sucesso!");
            else
                Console.WriteLine("Paciente não encontrado.");
            Pause();
        }

        private void Atender()
        {
            if (filaTriagem.Count == 0)
            {
                Console.WriteLine("Fila vazia.");
            }
            else
            {
                Paciente p = filaTriagem.Dequeue();
                Console.WriteLine("Atendendo:");
                Console.WriteLine(p);
                historico.Push(p);
            }
            Pause();
        }

        private void Historico()
        {
            Console.WriteLine("=== HISTÓRICO ===");
            foreach (var p in historico)
            {
                Console.WriteLine(p);
                Console.WriteLine("-----------------");
            }
            Pause();
        }

        private void Pause()
        {
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
        }
    }
}

