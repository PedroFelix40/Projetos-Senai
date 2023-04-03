
Console.WriteLine(@$"
________________________
|  Escolha uma bebida  |
| 1. Coca cola         |
| 2. Pepsi             |
| 3. Guarana           |
| 4. Chá               |
| 5. Agua              |
------------------------
");
int bebidas = int.Parse(Console.ReadLine());

string gelo = "";

switch (bebidas)
{
    case 1:
        Console.WriteLine($"Gostaria de acrescentar gelo?");
        string gelo = Console.ReadLine() .ToUpper();
        
        if ( gelo == "SIM" )
        {
            Console.WriteLine($"Seu pedido foi {bebidas}, com gelo");
        }
        else 
        {
            Console.WriteLine($"Seu pedido foi {bebidas}, sem gelo");
            
        }
        break;
    
    case 2:
        Console.WriteLine($"Gostaria de acrescentar gelo?");
        string gelo = Console.ReadLine() .ToUpper();
        
        if ( gelo == "SIM" )
        {
            Console.WriteLine($"Seu pedido foi {bebidas}, com gelo");
        }
        else 
        {
            Console.WriteLine($"Seu pedido foi {bebidas}, sem gelo");
            
        }
        break;
    
    case 3:
        Console.WriteLine($"Gostaria de acrescentar gelo?");
        string gelo = Console.ReadLine() .ToUpper();
        
        if ( gelo == "SIM" )
        {
            Console.WriteLine($"Seu pedido foi {bebidas}, com gelo");
        }
        else 
        {
            Console.WriteLine($"Seu pedido foi {bebidas}, sem gelo");
            
        }
        break;
    
    case 4:
        Console.WriteLine($"Gostaria de acrescentar gelo?");
        string gelo = Console.ReadLine() .ToUpper();
        
        if ( gelo == "SIM" )
        {
            Console.WriteLine($"Seu pedido foi {bebidas}, com gelo");
        }
        else 
        {
            Console.WriteLine($"Seu pedido foi {bebidas}, sem gelo");
            
        }
        break;
    
    case 5:
        Console.WriteLine($"Gostaria de acrescentar gelo?");
        string gelo = Console.ReadLine() .ToUpper();
        
        if ( gelo == "SIM" )
        {
            Console.WriteLine($"Seu pedido foi {bebidas}, com gelo");
        }
        else 
        {
            Console.WriteLine($"Seu pedido foi {bebidas}, sem gelo");
            
        }
        break;
    
    default:
        break;
}

