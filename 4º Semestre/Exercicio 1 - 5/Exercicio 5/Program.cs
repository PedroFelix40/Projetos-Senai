// Crie um programa que peça ao usuário para digitar um texto e conte quantas vezes cada
// letra do alfabeto aparece no texto.

using System.Text.RegularExpressions;

string textUser;
Console.WriteLine($"Digite um texto, e em seguida diremos quantas vezes cada letra do alfabeto aparece no texto: ");
textUser = Console.ReadLine()!;

string source = "/once/upon/a/time/";
int count = 0;
foreach (char c in textUser)
{
    if (c == 'e')
    {
        count++;
    }
}
Console.WriteLine(count);

