using System;

namespace MenuEstruturasDados
{
    class Program
    {
        static void Main(string[] args)
        {
            bool sair = false;
            while (!sair)
            {
                Console.WriteLine("Menu Principal:");
                Console.WriteLine("1 - Vetores");
                Console.WriteLine("2 - Matrizes");
                Console.WriteLine("3 - Trabalhar com Lista");
                Console.WriteLine("4 - Trabalhar com Fila");
                Console.WriteLine("5 - Trabalhar com Pilha");
                Console.WriteLine("6 - Algoritmos de Pesquisa");
                Console.WriteLine("7 - Sair");
                Console.Write("Escolha uma opção: ");

                string? escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        VetorMenu.ExibirMenu();
                        break;
                    case "2":
                        MatrizMenu.ExibirMenu();
                        break;
                    case "3":
                        ListaMenu.ExibirMenu();
                        break;
                    case "4":
                        FilaMenu.ExibirMenu();
                        break;
                    case "5":
                        PilhaMenu.ExibirMenu();
                        break;
                    case "6":
                        PesquisaMenu.ExibirMenu();
                        break;
                    case "7":
                        sair = true;
                        Console.WriteLine("Encerrando o programa.");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}