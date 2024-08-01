using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_3_solucao
{
    public class CalculoFahrenheit
    {
        public static double ConverterCelsiusParaFahrenheit(int grausCelcius)
        {
            return Math.Round( ((grausCelcius * 1.8) + 32) , 1);
        }
    }
}
