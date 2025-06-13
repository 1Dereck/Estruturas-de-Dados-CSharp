using System;
using System.Collections.Generic;
using System.Linq;

namespace PRojeto_11
{
    // Classe que representa um pedido no restaurante
    public class Pedido
    {
        public int Numero { get; set; }             // Número único do pedido
        public int Mesa { get; set; }               // Número da mesa
        public List<string> Itens { get; set; }     // Lista de itens pedidos
        public string Status { get; set; } = "Em preparo"; // Status do pedido

        // Construtor para inicializar os dados do pedido
        public Pedido(int numero, int mesa, List<string> itens)
        {
            Numero = numero;
            Mesa = mesa;
            Itens = itens;
        }

        // Método para exibir o pedido como texto formatado
        public override string ToString()
        {
            string itensFormatados = string.Join(", ", Itens);
            return $"Pedido #{Numero} | Mesa: {Mesa} | Itens: {itensFormatados} | Status: {Status}";
        }
    }
}
