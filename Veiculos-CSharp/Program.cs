namespace Desafio_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Veiculo> listaVeiculos = new List<Veiculo>();
            Dictionary<string, Veiculo> dicionarioPlacas = new Dictionary<string, Veiculo>();

            bool rodando = true;
            while (rodando)
            {
                Console.Clear();
                Console.WriteLine("\r\n ██▒   █▓▓█████  ██▓ ▄████▄   █    ██  ██▓     ▒█████    ██████ \r\n▓██░   █▒▓█   ▀ ▓██▒▒██▀ ▀█   ██  ▓██▒▓██▒    ▒██▒  ██▒▒██    ▒ \r\n ▓██  █▒░▒███   ▒██▒▒▓█    ▄ ▓██  ▒██░▒██░    ▒██░  ██▒░ ▓██▄   \r\n  ▒██ █░░▒▓█  ▄ ░██░▒▓▓▄ ▄██▒▓▓█  ░██░▒██░    ▒██   ██░  ▒   ██▒\r\n   ▒▀█░  ░▒████▒░██░▒ ▓███▀ ░▒▒█████▓ ░██████▒░ ████▓▒░▒██████▒▒\r\n   ░ ▐░  ░░ ▒░ ░░▓  ░ ░▒ ▒  ░░▒▓▒ ▒ ▒ ░ ▒░▓  ░░ ▒░▒░▒░ ▒ ▒▓▒ ▒ ░\r\n   ░ ░░   ░ ░  ░ ▒ ░  ░  ▒   ░░▒░ ░ ░ ░ ░ ▒  ░  ░ ▒ ▒░ ░ ░▒  ░ ░\r\n     ░░     ░    ▒ ░░         ░░░ ░ ░   ░ ░   ░ ░ ░ ▒  ░  ░  ░  \r\n      ░     ░  ░ ░  ░ ░         ░         ░  ░    ░ ░        ░  \r\n     ░              ░                                           \r\n");
                Console.WriteLine("\n1. Cadastrar Veículo\n2. Listar Veículos\n3. Buscar Veículo\n4. Atualizar Veículo\n5. Remover Veículo\n6. Sair");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine()!;

                switch (opcao)
                {
                    case "1":
                        Console.Clear();
                        Console.Write("Placa: ");
                        string placa = Console.ReadLine()!;
                        if (dicionarioPlacas.ContainsKey(placa))
                        {
                            Console.WriteLine("Veículo já cadastrado!");
                            break;
                        }
                        Console.Write("Modelo: ");
                        string modelo = Console.ReadLine()!;
                        Console.Write("Ano: ");
                        int ano = int.Parse(Console.ReadLine()!);
                        Veiculo novo = new Veiculo(placa, modelo, ano);
                        listaVeiculos.Add(novo);
                        dicionarioPlacas[placa] = novo;
                        Console.WriteLine("Veículo cadastrado.");
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("\n--- Veículos Cadastrados ---");
                        foreach (var v in listaVeiculos)
                            Console.WriteLine(v);
                        break;

                    case "3":
                        Console.Clear();
                        Console.Write("Digite a placa ou modelo: ");
                        string busca = Console.ReadLine()!;
                        if (dicionarioPlacas.ContainsKey(busca))
                        {
                            Console.WriteLine("Encontrado: " + dicionarioPlacas[busca]);
                        }
                        else
                        {
                            var encontrados = listaVeiculos.Where(v => v.Modelo.Contains(busca)).ToList();
                            if (encontrados.Count > 0)
                                encontrados.ForEach(v => Console.WriteLine(v));
                            else
                                Console.WriteLine("Nenhum veículo encontrado.");
                        }
                        break;

                    case "4":
                        Console.Clear();
                        Console.Write("Digite a placa do veículo a atualizar: ");
                        string placaUpdate = Console.ReadLine()!;
                        if (dicionarioPlacas.TryGetValue(placaUpdate, out Veiculo veiculoAtualizar))
                        {
                            Console.Write("Novo modelo: ");
                            veiculoAtualizar.Modelo = Console.ReadLine()!;
                            Console.Write("Novo ano: ");
                            veiculoAtualizar.Ano = int.Parse(Console.ReadLine()!);
                            Console.WriteLine("Veículo atualizado.");
                        }
                        else Console.WriteLine("Veículo não encontrado.");
                        break;

                    case "5":
                        Console.Clear();
                        Console.Write("Digite a placa do veículo a remover: ");
                        string placaRemover = Console.ReadLine()!;
                        if (dicionarioPlacas.TryGetValue(placaRemover, out Veiculo veiculoRemover))
                        {
                            listaVeiculos.Remove(veiculoRemover);
                            dicionarioPlacas.Remove(placaRemover);
                            Console.WriteLine("Veículo removido.");
                        }
                        else Console.WriteLine("Veículo não encontrado.");
                        break;

                    case "6":
                        rodando = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }

        }
    }
}
