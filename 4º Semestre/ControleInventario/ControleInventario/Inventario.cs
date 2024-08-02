using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleInventario
{
    public static class Inventario
    {
        public static List<Produto> AdicionarProduto(string nome, int qnt)
        {
			try
			{
				List<Produto> listProduto = new();

				Produto produto = new();

				produto.Nome = nome;
				produto.Quantidade = qnt;

				var contain = listProduto.Contains(produto);

				if (contain == true) 
				{
					foreach(var p in listProduto) 
					{
						p.Quantidade = p.Quantidade ++;
					}
				}
				else
				{
                    listProduto.Add(produto);
                }

                

				return listProduto;
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
