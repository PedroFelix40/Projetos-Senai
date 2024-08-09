using ConversaoTemperatura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteConversaoCToF
{
    public class TesteConv
    {
        [Fact]
        public void TesteConversao()
        {
            var celsius = 0;
            var fah = 32;

            var fahConv = ConverterCToF.ConvercaoCToF(celsius);

            Assert.Equal(fah, fahConv);
        }
    }
}
