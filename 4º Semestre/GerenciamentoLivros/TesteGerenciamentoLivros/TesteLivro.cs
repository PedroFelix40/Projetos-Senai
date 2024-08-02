using GerenciamentoLivros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteGerenciamentoLivros
{
    public class TesteLivro
    {
        [Fact]
        public void TesteAdicionar() 
        {
            // Definindo o que será passado na função
            var nomeLivro = "Conto de Fadas";
            var autorLivro = "EU";     
            var valorEsperado = true;

            // Chamando a função, e guardando em uma variável
            var livro = GerenciarLivro.AdicionarLivro(nomeLivro, autorLivro);

            // Criando uma variável booleana
            var livroBool = false;

            // Verificando se o objeto livro tem algo
            if (livro.Count > 0)
            {
                // Caso tenha, transforma a variavel em true
                livroBool = true;
            }

            // Compara o valor esperado com o valor retornado
            Assert.Equal(valorEsperado, livroBool);
        }
    }
}
