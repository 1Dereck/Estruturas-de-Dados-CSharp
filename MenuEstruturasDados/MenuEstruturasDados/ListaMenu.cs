using System;
using System.Collections.Generic;

namespace MenuEstruturasDados
{
    class ListaMenu
    {
        private static List<int> lista = new List<int>();

        public static void ExibirMenu()
        {
            bool voltar = false;
            while (!voltar)
            {
                Console.WriteLine("Menu de Lista:");
                Console.WriteLine("1 - Inserir elemento");
                Console.WriteLine("2 - Remover elemento");
                Console.WriteLine("3 - Exibir todos os elementos");
                Console.WriteLine("4 - Consultar elemento");
                Console.WriteLine("5 - Voltar ao Menu Principal");
                Console.Write("Escolha uma opção: ");

                string? escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        InserirElemento();
                        break;
                    case "2":
                        RemoverElemento();
                        break;
                    case "3":
                        ExibirElementos();
                        break;
                    case "4":
                        ConsultarElemento();
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

        private static void InserirElemento()
        {
            Console.Write("Digite o elemento a ser inserido: ");
            if (int.TryParse(Console.ReadLine(), out int elemento))
            {
                lista.Add(elemento);
                Console.WriteLine($"{elemento} inserido na lista.");
            }
            else
            {
                Console.WriteLine("Entrada inválida.");
            }
        }

        private static void RemoverElemento()
        {
            if (lista.Count == 0)
            {
                Console.WriteLine("A lista está vazia.");
                return;
            }
            Console.Write("Digite o elemento a ser removido: ");
            if (int.TryParse(Console.ReadLine(), out int elemento))
            {
                if (lista.Remove(elemento))
                {
                    Console.WriteLine($"{elemento} removido da lista.");
                }
                else
                {
                    Console.WriteLine($"{elemento} não encontrado na lista.");
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida.");
            }
        }

        private static void ExibirElementos()
        {
            if (lista.Count == 0)
            {
                Console.WriteLine("A lista está vazia.");
                return;
            }
            Console.WriteLine("Elementos na lista:");
            foreach (int elemento in lista)
            {
                Console.Write($"{elemento} ");
            }
            Console.WriteLine();
        }

        private static void ConsultarElemento()
        {
            if (lista.Count == 0)
            {
                Console.WriteLine("A lista está vazia.");
                return;
            }
            Console.Write("Digite o elemento a ser consultado: ");
            if (int.TryParse(Console.ReadLine(), out int elemento))
            {
                if (lista.Contains(elemento))
                {
                    Console.WriteLine($"{elemento} encontrado na lista.");
                }
                else
                {
                    Console.WriteLine($"{elemento} não encontrado na lista.");
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida.");
            }
        }
    }
}