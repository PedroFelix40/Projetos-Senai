// See https://aka.ms/new-console-template for more information
using ValidacaoEmail;

Console.WriteLine("Hello, World!");

var retorno = ValidarEmail.ValidacaoEmail("pedro@gm.com");

Console.WriteLine(retorno.ToString());