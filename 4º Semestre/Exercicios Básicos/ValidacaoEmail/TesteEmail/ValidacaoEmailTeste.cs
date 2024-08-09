using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidacaoEmail;

namespace TesteEmail
{
    public class ValidacaoEmailTeste
    {
        [Fact]
        public void ValidacaoTeste() 
        {
            // Variavel email
            var email = "pedro@gm.com";
            var emailEsperado = true;

            var emailBool = ValidarEmail.ValidacaoEmail(email);

            // Comparando os valores
            Assert.Equal(emailEsperado, emailBool);
        }
    }
}
