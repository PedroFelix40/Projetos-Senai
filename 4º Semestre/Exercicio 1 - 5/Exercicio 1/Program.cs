// Escreva um programa que peça ao usuário para digitar um número inteiro e informe se o número é par ou ímpar. Utilize uma estrutura condicional if/else para realizar o teste.

double num = 0;
do
{
    Console.WriteLine($"**********************************************************");
    Console.WriteLine($"Digite um número, e em seguida diremos se é par ou ímpar: ");
    //num = double.Parse(Console.ReadLine()!);

    while (!double.TryParse(Console.ReadLine(), out num))
    {
        Console.WriteLine("Insira apenas valores numericos: ");
    }

    Console.WriteLine(num % 2 == 0 ? $"O número {num} é par." : $"O número {num} é ímpar");
} while (true);
