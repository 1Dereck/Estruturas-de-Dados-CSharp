// FilaMenu.cs
using System;
using System.Collections.Generic;

namespace MenuEstruturasDados
{
    class FilaMenu
    {
        private static Queue<int> fila = new Queue<int>();

        public static void ExibirMenu()
        {
            bool voltar = false;
            while (!voltar)
            {
                Console.WriteLine("Menu de Fila:");
                Console.WriteLine("1 - Enfileirar elemento");
                Console.WriteLine("2 - Desenfileirar elemento");
                Console.WriteLine("3 - Exibir o elemento da frente");
                Console.WriteLine("4 - Exibir todos os elementos");
                Console.WriteLine("5 - Voltar ao Menu Principal");
                Console.Write("Escolha uma opção: ");

                string? escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        EnfileirarElemento();
                        break;
                    case "2":
                        DesenfileirarElemento();
                        break;
                    case "3":
                        ExibirFrente();
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

        private static void EnfileirarElemento()
        {
            Console.Write("Digite o elemento a ser enfileirado: ");
            if (int.TryParse(Console.ReadLine(), out int elemento))
            {
                fila.Enqueue(elemento);
                Console.WriteLine($"{elemento} enfileirado.");
            }
            else
            {
                Console.WriteLine("Entrada inválida.");
            }
        }

        private static void DesenfileirarElemento()
        {
            if (fila.Count == 0)
            {
                Console.WriteLine("A fila está vazia.");
                return;
            }
            int elemento = fila.Dequeue();
            Console.WriteLine($"{elemento} desenfileirado.");
        }

        private static void ExibirFrente()
        {
            if (fila.Count == 0)
            {
                Console.WriteLine("A fila está vazia.");
                return;
            }
            Console.WriteLine($"Elemento da frente: {fila.Peek()}");
        }

        private static void ExibirElementos()
        {
            if (fila.Count == 0)
            {
                Console.WriteLine("A fila está vazia.");
                return;
            }
            Console.WriteLine("Elementos na fila:");
            foreach (int elemento in fila)
            {
                Console.Write($"{elemento} ");
            }
            Console.WriteLine();
        }
    }
}