// See https://aka.ms/new-console-template for more information
using ControleInventario;

Console.WriteLine("Hello, World!");

var produtos = Inventario.AdicionarProduto("sim", 2);

Console.WriteLine(produtos);

foreach (var item in produtos)
{
    Console.WriteLine(item.Nome);
}