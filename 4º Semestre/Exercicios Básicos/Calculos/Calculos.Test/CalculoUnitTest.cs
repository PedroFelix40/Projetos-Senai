using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculos.Test
{
    public class CalculoUnitTest
    {
        [Fact]
        public void SomarDoisNumeros()
        {
            var n1 = 3.3;
            var n2 = 2.2;
            var valorEsperado = 5.5;

            var soma = Calculo.Somar(n1, n2);

            Assert.Equal(valorEsperado, soma);
        }

        [Fact]
        public void SubtrairDoisNumeros()
        {
            var n1 = 3;
            var n2 = 2;
            var valorEsperado = 1;

            var subtracao = Calculo.Subtracao(n1, n2);

            Assert.Equal(valorEsperado, subtracao);
        }

        [Fact]
        public void MultiplicacaoDoisNumeros()
        {
            // Organizar (Arrange)
            var n1 = 3;
            var n2 = 2;
            var valorEsperado = 6;

            // Agir (Act)
            var multiplicacao = Calculo.Multiplicacao(n1, n2);

            // Provar (Assert)
            Assert.Equal(valorEsperado, multiplicacao);
        }

        [Fact]
        public void DividirDoisNumeros()
        {
            var n1 = 4;
            var n2 = 2;
            var valorEsperado = 2;

            var dividir = Calculo.Divisao(n1, n2);

            Assert.Equal(valorEsperado, dividir);
        }
    }
}
