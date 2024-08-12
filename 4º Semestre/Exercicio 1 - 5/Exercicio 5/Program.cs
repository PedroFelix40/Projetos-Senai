// Crie um programa que peça ao usuário para digitar um texto e conte quantas vezes cada
// letra do alfabeto aparece no texto.

using System.Text.RegularExpressions;

string texto = "";

Console.WriteLine($"Digite um texto, e em seguida diremos quantas vezes cada letra do alfabeto aparece no texto: ");
texto = Console.ReadLine()!;

Dictionary<char, int> letras = [];

foreach (char c in texto.ToLower())
{
    if (char.IsLetter(c))
    {
        if (letras.ContainsKey(c))
        {
            letras[c]++;
        }
        else
        {
            letras.Add(c, 1);
        }
    }
}
foreach (var letra in letras)
{
    Console.WriteLine($"Letra: '{letra.Key}' apareceu {letra.Value} vezes.");
}