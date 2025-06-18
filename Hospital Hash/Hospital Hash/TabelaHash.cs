using System;

namespace SistemaClinicoHash
{
    public class TabelaHash
    {
        private LinkedList<KeyValuePair<string, Paciente>>[] buckets;

        public TabelaHash(int tamanho = 10)
        {
            buckets = new LinkedList<KeyValuePair<string, Paciente>>[tamanho];
            for (int i = 0; i < tamanho; i++)
                buckets[i] = new LinkedList<KeyValuePair<string, Paciente>>();
        }

        private int FuncaoHash(string chave)
        {
            return Math.Abs(chave.GetHashCode()) % buckets.Length;
        }

        public void Inserir(Paciente paciente)
        {
            int indice = FuncaoHash(paciente.CPF);
            var lista = buckets[indice];

            foreach (var kvp in lista)
            {
                if (kvp.Key == paciente.CPF)
                {
                    Console.WriteLine("CPF já cadastrado!");
                    return;
                }
            }

            lista.AddLast(new KeyValuePair<string, Paciente>(paciente.CPF, paciente));
        }

        public Paciente Buscar(string cpf)
        {
            int indice = FuncaoHash(cpf);
            foreach (var kvp in buckets[indice])
            {
                if (kvp.Key == cpf)
                    return kvp.Value;
            }
            return null;
        }

        public bool Remover(string cpf)
        {
            int indice = FuncaoHash(cpf);
            var lista = buckets[indice];

            var node = lista.First;
            while (node != null)
            {
                if (node.Value.Key == cpf)
                {
                    lista.Remove(node);
                    return true;
                }
                node = node.Next;
            }
            return false;
        }

        public bool Atualizar(string cpf, double novaPA, double novaTemp, double novaOx)
        {
            var paciente = Buscar(cpf);
            if (paciente != null)
            {
                paciente.Pressao = novaPA;
                paciente.Temperatura = novaTemp;
                paciente.Oxigenacao = novaOx;
                paciente.ClassificarPrioridade();
                return true;
            }
            return false;
        }

        public void ExibirTabela()
        {
            for (int i = 0; i < buckets.Length; i++)
            {
                Console.Write($"[{i}]: ");
                foreach (var kvp in buckets[i])
                {
                    Console.ForegroundColor = kvp.Value.Prioridade switch
                    {
                        "Vermelha" => ConsoleColor.Red,
                        "Amarela" => ConsoleColor.Yellow,
                        _ => ConsoleColor.Green
                    };
                    Console.Write($"[{kvp.Key}] ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
    }
}
