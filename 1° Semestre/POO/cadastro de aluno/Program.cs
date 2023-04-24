
// Nome, Curso, Idade, RG, Bolsista (boolean), Média Final e Valor da Mensalidade. 
// Também teremos os métodos: 

using cadastro_de_aluno;


Aluno aluno = new Aluno();


Console.WriteLine($"Informe seu nome: ");
aluno.nome = Console.ReadLine()!;

Console.WriteLine($"Informe seu curso: ");
aluno.curso = Console.ReadLine()!;

Console.WriteLine($"Informe sua idade: ");
aluno.idade = Console.ReadLine()!;

Console.WriteLine($"Informe seu RG: ");
aluno.rg = Console.ReadLine()!;

Console.WriteLine($"Informe caso seja bolsista: s/n");
string bolsa = Console.ReadLine()!.ToLower();

Console.WriteLine($"Informe sua média final: ");
aluno.mediaFinal = int.Parse(Console.ReadLine()!);


Console.WriteLine($"Informe sua mensalidade: ");
aluno.valorMensalidade = float.Parse(Console.ReadLine()!);

float valorMensalidadeFinal = aluno.ValorMensalidade( aluno.mediaFinal);

Console.WriteLine(valorMensalidadeFinal);





