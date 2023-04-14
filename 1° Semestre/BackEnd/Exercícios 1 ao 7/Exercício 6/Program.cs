
// - Escreva um algoritmo que permita a leitura dos nomes de 10 pessoas e armazene os nomes
// lidos em um vetor. Após isto, o algoritmo deve permitir a leitura de mais 1 nome qualquer de
// pessoa (para efetuar uma busca) e depois escrever a mensagem ACHEI, se o nome estiver
// entre os 10 nomes lidos anteriormente (guardados no vetor), ou NÃO ACHEI caso contrário.

string[] nomes = new string[3];

for (var i = 0; i < 3; i++)
{
    Console.WriteLine($"Informe o {i +1}º: ");
    nomes[i] = Console.ReadLine()!;
}

for (var i = 0; i < 3; i++)
{
    if (nomes[i] == "pedro")
    {
        Console.WriteLine($"Achei o nome!!!!");
        
    }
    else
    {
        Console.WriteLine($"Poxaa. Não achei nome.");
        
    }
}