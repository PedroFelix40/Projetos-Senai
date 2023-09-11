using Exercício___2;

int adicionarAcucar;

MaquinaCafe maquina = new MaquinaCafe();

System.Console.WriteLine(@$"
Super CafeteiraTabajaras Plus++
Quantas gramas(g) deseja adicionar:
");
adicionarAcucar = int.Parse(Console.ReadLine()!.ToLower());

if(adicionarAcucar >= 1)
{
    maquina.FazerCafe(adicionarAcucar);
}
else
{
    System.Console.WriteLine("Será adicionada 10g de açucar ao se café.");
}