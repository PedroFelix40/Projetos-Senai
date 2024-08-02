using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoLivros
{
    public static class GerenciarLivro
    {
        public static List<Livro> AdicionarLivro(string nomeLivro, string autorLivro)
        {
			try
			{
				Livro livro = new Livro();

				List<Livro> listLivro = new List<Livro>();

				livro.nomeLivro = nomeLivro;
				livro.autorLivro = autorLivro;

				listLivro.Add(livro);
				return listLivro;
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
