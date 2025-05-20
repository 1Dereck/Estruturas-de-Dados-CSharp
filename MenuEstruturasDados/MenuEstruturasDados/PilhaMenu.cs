using System;
using System.Collections.Generic;

namespace MenuEstruturasDados
{
    class PilhaMenu
    {
        private static Stack<int> pilha = new Stack<int>();

        public static void ExibirMenu()
        {
            bool voltar = false;
            while (!voltar)
            {
                Console.WriteLine("Menu de Pilha:");
                Console.WriteLine("1 - Empilhar elemento");
                Console.WriteLine("2 - Desempilhar elemento");
                Console.WriteLine("3 - Exibir o elemento do topo");
                Console.WriteLine("4 - Exibir todos os elementos");
                Console.WriteLine("5 - Voltar ao Menu Principal");
                Console.Write("Escolha uma opção: ");

                string? escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        EmpilharElemento();
                        break;
                    case "2":
                        DesempilharElemento();
                        break;
                    case "3":
                        ExibirTopo();
                        break;
                    case "4":
                        ExibirElementos();
                        break;
                    case "5":
                        voltar = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
                Console.WriteLine();
            }
        }

        private static void EmpilharElemento()
        {
            Console.Write("Digite o elemento a ser empilhado: ");
            if (int.TryParse(Console.ReadLine(), out int elemento))
            {
                pilha.Push(elemento);
                Console.WriteLine($"{elemento} empilhado.");
            }
            else
            {
                Console.WriteLine("Entrada inválida.");
            }
        }

        private static void DesempilharElemento()
        {
            if (pilha.Count == 0)
            {
                Console.WriteLine("A pilha está vazia.");
                return;
            }
            int elemento = pilha.Pop();
            Console.WriteLine($"{elemento} desempilhado.");
        }

        private static void ExibirTopo()
        {
            if (pilha.Count == 0)
            {
                Console.WriteLine("A pilha está vazia.");
                return;
            }
            Console.WriteLine($"Elemento do topo: {pilha.Peek()}");
        }

        private static void ExibirElementos()
        {
            if (pilha.Count == 0)
            {
                Console.WriteLine("A pilha está vazia.");
                return;
            }
            Console.WriteLine("Elementos na pilha (do topo para a base):");
            foreach (int elemento in pilha)
            {
                Console.WriteLine(elemento);
            }
        }
    }
}