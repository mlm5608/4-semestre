using Exercicio_2_solucao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_2.Test
{
    public class ValidacaoTest
    {
        [Theory]
        [InlineData("EmailTeste@gmail.com.br")]
        [InlineData("EmailTeste")]

        public void ValidaEmailCorreto(string email)
        {
            var resp = ValidarEmail.Validacao(email);

            Assert.True(resp);
        }
    }
}
