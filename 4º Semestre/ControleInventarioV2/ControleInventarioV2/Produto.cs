using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleInventarioV2
{
    public class Produto
    {
        public string Nome { get; set; }
        public int Quantidade { get; set; }

        public Produto(string nome, int quantidade)
        {
            Nome = nome;
            Quantidade = quantidade;
        }
    }
}
