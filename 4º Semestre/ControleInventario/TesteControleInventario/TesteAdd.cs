using ControleInventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteControleInventario
{
    public class TesteAdd
    {
        [Fact]
        public void TesteAdicionar()
        {
            var nomeProduto = "Leite";
            var quantidade = 2;
            var valorEsperado = true;

            var listaDeProdutos = Inventario.AdicionarProduto(nomeProduto, quantidade);

            var produtoBool = false;

            if (listaDeProdutos.Count > 0)
            {
                produtoBool = true;
            }

            Assert.Equal(valorEsperado, produtoBool);
        }
    }
}
