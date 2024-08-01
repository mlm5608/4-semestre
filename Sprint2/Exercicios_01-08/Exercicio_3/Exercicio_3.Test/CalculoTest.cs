using Exercicio_3_solucao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_3.Test
{
    public class CalculoTest
    {
        [Fact]
        public void TesteCalculo()
        {
            var resp = 73.4;
            var grausC = 23;

            var conta = CalculoFahrenheit.ConverterCelsiusParaFahrenheit(grausC);

            Assert.Equal(resp, conta);
        }
    }
}
