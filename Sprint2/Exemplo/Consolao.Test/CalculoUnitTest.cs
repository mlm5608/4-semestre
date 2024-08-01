using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsolaoProject;

namespace Consolao.Test
{
    public class CalculoUnitTest
    {
        //princípio AAA: Act, Arange, Assert => agir, organizar, Provar
        public void SomarDoisNumeros()
        {
            //Organizar
            var n1 = 8.39;
            var n2 = 6.75;
            var valorEsperado = 15.14;

            //Agir
            var Soma = calculoConsolao.Somar(n1, n2);

            //Provar
            Assert.Equal(valorEsperado, Soma);
        }

        
        public void SubtrairDoisNumeros()
        {
            var n1 = 8.3;
            var n2 = 6.1;
            var valorEsperado = 2.2;

            var Soma = calculoConsolao.Subtrair(n1, n2);

            Assert.Equal(valorEsperado, Soma);
        }

        
        public void MultipilcarDoisNumeros()
        {
            var n1 = 8.0;
            var n2 = 6.4;
            var valorEsperado = 51.2;

            var Soma = calculoConsolao.multiplicar(n1, n2);

            Assert.Equal(valorEsperado, Soma);
        }

        
        public void DividirDoisNumeros()
        {
            var n1 = 8.2;
            var n2 = 4.1;
            var valorEsperado = 2;

            var Soma = calculoConsolao.Divisao(n1, n2);

            Assert.Equal(valorEsperado, Soma);
        }

        
        public void ModularNumero()
        {
            var n1 = 4;
            var valorEsperado = 2;

            var Soma = calculoConsolao.Modular(n1);

            Assert.Equal(valorEsperado, Soma);
        }

        
        public void PotenciarNumero()
        {
            var n1 = 2.25;
            var valorEsperado = 5.0625;

            var Soma = calculoConsolao.Potenciacao(n1);

            Assert.Equal(valorEsperado, Soma);
        }

        [Fact]
        public void RadciarNumero()
        {
            var n1 = 16;
            var valorEsperado = 4;

            var Soma = calculoConsolao.Radiciação(n1);

            Assert.Equal(valorEsperado, Soma);
        }
    }
}
