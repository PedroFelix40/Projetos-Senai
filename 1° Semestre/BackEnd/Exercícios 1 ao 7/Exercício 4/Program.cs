﻿// 4 - Faça um programa que leia 10 valores digitados pelo usuário e no final, escreva o maior e o
// menor valor lido.

int[] numeros = new int [10];

for (var i = 0; i < 10; i++)
{
    Console.WriteLine($"Informe o {i +1}º número: ");
    numeros[i] = int.Parse(Console.ReadLine()!);
}

Console.WriteLine($"O maior número é {numeros.Max()} e o menor número é {numeros.Min()}");

