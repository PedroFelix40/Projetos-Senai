// Crie um programa que calcule a soma dos números pares de um vetor de 10 elementos.
// Utilize um laço for para percorrer o vetor e uma estrutura condicional if para identificar
// os números pares.

double[] num = new double[10];
double somaPares = 0;
Console.WriteLine($"Digite 10 números, faremos a soma dos números pares...");

for (int i = 0; i < num.Length; i++)
{
    Console.WriteLine($"Digite o {i + 1}º número: ");
    num[i] = double.Parse(Console.ReadLine()!);

    if (num[i] % 2 == 0)
    {
        somaPares += num[i];
    }
}

Console.WriteLine($"Soma dos numeros pares {somaPares}");

