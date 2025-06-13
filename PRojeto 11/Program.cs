using System;
using System.Collections.Generic;
using System.Linq;

namespace PRojeto_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Lista para armazenar todos os pedidos
            List<Pedido> listaPedidos = new List<Pedido>();

            // Dicionário para buscar rapidamente pedidos pelo número
            Dictionary<int, Pedido> dicionarioPedidos = new Dictionary<int, Pedido>();

            bool rodando = true;

            while (rodando)
            {
                Console.Clear();
                // Cabeçalho estilizado
                Console.WriteLine("\r\n███████╗██████╗  ██████╗ ████████╗ █████╗ ███████╗\r\n██╔════╝██╔══██╗██╔═══██╗╚══██╔══╝██╔══██╗██╔════╝\r\n█████╗  ██████╔╝██║   ██║   ██║   ███████║███████╗\r\n██╔══╝  ██╔══██╗██║   ██║   ██║   ██╔══██║╚════██║\r\n██║     ██║  ██║╚██████╔╝   ██║   ██║  ██║███████║\r\n╚═╝     ╚═╝  ╚═╝ ╚═════╝    ╚═╝   ╚═╝  ╚═╝╚══════╝\r\n");

                // Menu de opções
                Console.WriteLine("\n1. Cadastrar Pedido\n2. Listar Pedidos\n3. Buscar Pedido\n4. Atualizar Status\n5. Remover Pedido\n6. Sair");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine()!;

                switch (opcao)
                {
                    case "1":
                        Console.Clear();
                        Console.Write("Número do pedido: ");
                        int numero = int.Parse(Console.ReadLine()!);

                        // Verifica se o pedido já existe
                        if (dicionarioPedidos.ContainsKey(numero))
                        {
                            Console.WriteLine("Pedido já existe!");
                            Console.ReadLine();
                            break;
                        }

                        // Coleta dados do novo pedido
                        Console.Write("Número da mesa: ");
                        int mesa = int.Parse(Console.ReadLine()!);
                        Console.Write("Itens (separados por vírgula): ");
                        var itens = Console.ReadLine()!.Split(',').Select(i => i.Trim()).ToList();

                        // Cria e armazena o pedido
                        Pedido novoPedido = new Pedido(numero, mesa, itens);
                        listaPedidos.Add(novoPedido);
                        dicionarioPedidos[numero] = novoPedido;

                        Console.WriteLine("Pedido cadastrado.");
                        Console.ReadLine();
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("\n--- Pedidos Cadastrados ---");

                        // Lista todos os pedidos cadastrados
                        if (listaPedidos.Count == 0)
                        {
                            Console.WriteLine("Nenhum pedido cadastrado.");
                        }
                        else
                        {
                            foreach (var p in listaPedidos)
                                Console.WriteLine(p);
                        }
                        Console.WriteLine("\nPressione Enter para voltar ao menu...");
                        Console.ReadLine();
                        break;

                    case "3":
                        Console.Clear();
                        Console.Write("Buscar por número do pedido ou número da mesa: ");
                        string busca = Console.ReadLine()!;

                        // Tenta converter a entrada para número
                        if (int.TryParse(busca, out int numeroBusca))
                        {
                            // Busca por número do pedido
                            if (dicionarioPedidos.TryGetValue(numeroBusca, out Pedido pedidoEncontrado))
                            {
                                Console.WriteLine("Encontrado: " + pedidoEncontrado);
                            }
                            else
                            {
                                // Caso não seja número do pedido, busca por número da mesa
                                var encontrados = listaPedidos.Where(p => p.Mesa == numeroBusca).ToList();
                                if (encontrados.Count > 0)
                                    encontrados.ForEach(p => Console.WriteLine(p));
                                else
                                    Console.WriteLine("Nenhum pedido encontrado.");
                            }
                        }
                        else Console.WriteLine("Número inválido.");
                        Console.ReadLine();
                        break;

                    case "4":
                        Console.Clear();
                        Console.Write("Número do pedido para atualizar: ");
                        int numAtualizar = int.Parse(Console.ReadLine()!);

                        // Verifica se o pedido existe
                        if (dicionarioPedidos.TryGetValue(numAtualizar, out Pedido pedidoAtualizar))
                        {
                            Console.Write("Novo status: ");
                            pedidoAtualizar.Status = Console.ReadLine()!;
                            Console.WriteLine("Status atualizado.");
                        }
                        else Console.WriteLine("Pedido não encontrado.");
                        Console.ReadLine();
                        break;

                    case "5":
                        Console.Clear();
                        Console.Write("Número do pedido para remover: ");
                        int numRemover = int.Parse(Console.ReadLine()!);

                        // Remove o pedido da lista e do dicionário
                        if (dicionarioPedidos.TryGetValue(numRemover, out Pedido pedidoRemover))
                        {
                            listaPedidos.Remove(pedidoRemover);
                            dicionarioPedidos.Remove(numRemover);
                            Console.WriteLine("Pedido removido.");
                        }
                        else Console.WriteLine("Pedido não encontrado.");
                        Console.ReadLine();
                        break;

                    case "6":
                        // Encerra o programa
                        rodando = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
