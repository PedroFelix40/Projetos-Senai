// Crie uma função que recebe um número como parâmetro e retorna a tabuada desse
// número até o número 10. Utilize um laço for para gerar os múltiplos do número.

double numSelect = 0;

Console.WriteLine($"Digite um número, e faremos uma tabuada do 1 ao 10...");
numSelect = double.Parse(Console.ReadLine()!);

for (int i = 1; i <= 10; i++)
{
    Console.WriteLine($"{i} x {numSelect} = {i*numSelect}");
}
