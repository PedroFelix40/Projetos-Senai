using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercício___2
{
    public class MaquinaCafe
    {
        public int AcucarDisponivel { get; set; } = 150;
        public int AdicionarAcucar;

        public string FazerCafe(int AdicionarAcucar)
        {
            if (AcucarDisponivel <= 0)
            {
                return $"Seu Café será sem açucar";
            }
            else
            {
                AcucarDisponivel = AdicionarAcucar - AcucarDisponivel;
                return $"Será adicionado {AdicionarAcucar}g";
            }
        }
    }
}