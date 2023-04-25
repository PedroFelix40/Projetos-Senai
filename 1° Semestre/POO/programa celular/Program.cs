
// Faça em sua máquina utilizando os mesmos conceitos dado em aula.
// Crie uma Classe de um Celular, com as propriedades cor, modelo, tamanho, ligado(booleano).
// Com os métodos, ligar, desligar, fazer ligação, enviar mensagem.
// Só será possível executar tais métodos se o celular estiver ligado.
// Envie o link do repositório como entrega desta atividade.

using programa_celular;

Celular novoCelular = new Celular();
string estaLigado;
string opcao;

Console.WriteLine($"--Informe as caracteristica do celular--");

Console.WriteLine($"Qual o modelo do celular: ");
novoCelular.Modelo = Console.ReadLine()!;

Console.WriteLine($"Informe a cor: ");
novoCelular.Cor = Console.ReadLine()!;

Console.WriteLine($"Informe o tamanho: ");
novoCelular.Tamanho = Console.ReadLine()!;

Console.WriteLine($"O celular está ligado? s/n");
estaLigado = Console.ReadLine()!.ToLower();
while (estaLigado != "s" && estaLigado != "n")
{
    Console.WriteLine($"Opção inválida. Por favor, digite novamente.");
    estaLigado = Console.ReadLine()!.ToLower();
}

if (estaLigado == "s")
{
    novoCelular.Ligado = true;
}
else
{
    novoCelular.Ligado = false;
    Console.WriteLine($"Deseja ligar? s/n");
    estaLigado = Console.ReadLine()!;
    

    
}

if (novoCelular.Ligado == true)
{
    do
    {  
    Console.WriteLine(@$"
    Celular ligado... O que deseja fazer: 
    (1) Fazer ligação
    (2) Enviar mensagem
    (0) Desligar
    ");
    opcao = Console.ReadLine()!;

    switch (opcao)
    {
        case "1":
            Console.WriteLine($"{novoCelular.FazerLigacao}");
            
            break;
        
        case "2":
            Console.WriteLine($"{novoCelular.EnviarMensagem}");
            
            break;
        default:
            break;
    }
    } while (opcao != "0");
        
}







