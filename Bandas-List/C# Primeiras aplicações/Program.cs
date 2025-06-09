string mensagemDeBoasVindas = "Boas vindas ao Screen Sound!\n";
List<string> listaDasBandas = new List<string> { "Yokai", "The Beatles", "Calypso"};
void ExibirMensagemDeBoasVindas()
{
    Console.WriteLine("------------------------------");
    Console.WriteLine(mensagemDeBoasVindas);
    Console.WriteLine("------------------------------");
}

void ExibirOpcoesDoMenu()
{
    Console.WriteLine("Digite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("Digite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    // a ! fala que não quer que volte um valor nulo, ou seja, que a variável não pode ser nula
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);
    switch (opcaoEscolhidaNumerica)
    {
        case 1:
            RegistrarBandas();
            break;
        case 2:
            MostrarAsBandasRegistradas();
            break;
        case 3:
            Console.WriteLine($"Você escolheu a opção {opcaoEscolhidaNumerica}");
            break;
        case 4:
            Console.WriteLine($"Você escolheu a opção {opcaoEscolhidaNumerica}");
            break;
        case -1:
            Console.WriteLine("Ate mais :)");
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }
}
void RegistrarBandas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro das bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    listaDasBandas.Add(nomeDaBanda);
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
    //Thread.Sleep(2000); // Pausa de 2 segundos para o usuário ler a mensagem
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void MostrarAsBandasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo todas as bandas registradas na nossa aplicação");
    //for (int i = 0; i < listaDasBandas.Count; i++)
    //{
    //    Console.WriteLine($"Banda: {listaDasBandas[i]}");
    //}

    foreach (string banda in listaDasBandas)
    {
        Console.WriteLine($"Banda: {banda}");
    }

    Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string tracos = string.Empty.PadLeft(quantidadeDeLetras, '-');
    Console.WriteLine(tracos);
    Console.WriteLine(titulo);
    Console.WriteLine(tracos + "\n");
}

ExibirOpcoesDoMenu();
