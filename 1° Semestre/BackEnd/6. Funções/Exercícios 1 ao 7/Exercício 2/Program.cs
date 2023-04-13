// - Um posto está vendendo combustíveis com a seguinte tabela de descontos:
// Álcool:
// . até 20 litros, desconto de 3% por litro Álcool
// . acima de 20 litros, desconto de 5% por litro
// Gasolina:
// . até 20 litros, desconto de 4% por litro Gasolina
// . acima de 20 litros, desconto de 6% por litro

// Escreva um algoritmo que leia o número de litros vendidos e o tipo de combustível (codificado
// da seguinte forma: A-álcool, G-gasolina), calcule e imprima o valor a ser pago pelo cliente
// sabendo-se que o preço do litro da gasolina é R$ 5,30 e o preço do litro do álcool é R$ 4,90.
// Dica: utilize switch case e funções/métodos para otimizar o algorítimo.

char combustivel;
double litros = 0;
double preco = 0;

Console.WriteLine($"Informe qual combustível você quer: (a)Álcool (g)Gasolina");
combustivel = char.Parse(Console.ReadLine()!);

Console.WriteLine($"Informe quantos litros de combutível você comprou: ");
litros = double.Parse(Console.ReadLine()!);

switch (combustivel)
{
    case 'a':
    preco = litros * 4.90f;

    if (litros <= 20)
    {
        preco = preco - (preco * 0.03);
        Console.WriteLine($"Você ganhou um desconto de 3%, e vai pagar: {Math.Round(preco,2)}");
    }
    else
    {
        preco = preco - (preco * 0.05);
        Console.WriteLine($"Você ganhou um desconto de 5%, e vai pagar: {Math.Round(preco,2)}");
    }
        break;
    
    case 'b':

        break;
    
    default:
        break;
}
