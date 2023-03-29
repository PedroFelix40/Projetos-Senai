// Calculo do dia de nascimento

var data = DateTime.Now;
Console.WriteLine($"{data}");


Console.WriteLine($"Digite o ano do seu nascimento");
int Ano = int.Parse(Console.ReadLine());

Console.WriteLine($"Digite o mês do seu nascimento");
int Mes = int.Parse(Console.ReadLine());

Console.WriteLine($"Digite o dia do seu nascimento");
int Dia = int.Parse(Console.ReadLine());

int CalcIdade = data.Year-Ano;
int CalcSem = CalcIdade*12*4;

Console.WriteLine($"{CalcIdade} {CalcSem}");


