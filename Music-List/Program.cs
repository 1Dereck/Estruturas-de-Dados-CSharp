using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Musicas;

namespace Musicas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> musicasPreSalvas = new List<string>();
            musicasPreSalvas.Add("Canavaro");
            musicasPreSalvas.Add("Lamentável, Pt. III");
            musicasPreSalvas.Add("Ninguem Morre me Devendo");

            int opcaoNumerica;
            do
            {
                Console.WriteLine("\r\n███╗   ███╗██╗   ██╗███████╗██╗ ██████╗\r\n████╗ ████║██║   ██║██╔════╝██║██╔════╝\r\n██╔████╔██║██║   ██║███████╗██║██║     \r\n██║╚██╔╝██║██║   ██║╚════██║██║██║     \r\n██║ ╚═╝ ██║╚██████╔╝███████║██║╚██████╗\r\n╚═╝     ╚═╝ ╚═════╝ ╚══════╝╚═╝ ╚═════╝\r\n                                       \r\n");
                Console.WriteLine("Digite a opção desejada:");
                Console.WriteLine("1) Salvar musica favorita");
                Console.WriteLine("2) Musicas salvas");
                Console.WriteLine("3) Finalizar sessão");
                
                string opcaoEscolhida = Console.ReadLine();
                opcaoNumerica = int.Parse(opcaoEscolhida);

                switch (opcaoNumerica)
                {
                    case 1:
                        string decisao;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine("Inclua uma musica que deseja:");
                            Console.WriteLine("-----------------------------\n");
                            Console.Write("Nome da musica: ");
                            string nomeMusic = Console.ReadLine();
                            musicasPreSalvas.Add(nomeMusic);

                            Console.WriteLine("\nDeseja adicionar outra música? (s/S para sim, qualquer outra tecla para voltar ao menu)");

                            decisao = Console.ReadLine();
                        }
                        while (decisao == "s" || decisao == "S");
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("-----------------------------");
                        Console.WriteLine("Exibindo todas as musicas...:");
                        Console.WriteLine("-----------------------------\n");
                        for (int i = 0;i < musicasPreSalvas.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}) {musicasPreSalvas[i]}");
                        }
                        Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("-----------------------------");
                        Console.WriteLine("Finalizando a sessão...");
                        Console.WriteLine("Obrigado(a) por usar o Music!");
                        Console.WriteLine("-----------------------------");
                        Thread.Sleep(2000);
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Tente novamente...");
                        break;
                }
            }
            while (opcaoNumerica != 3);
        }
    }
}
