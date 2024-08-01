using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaoProject
{
    public class calculoConsolao
    {
        public static double Somar(double x, double y)
        {
            return (x + y);
        }

        public static double Subtrair(double x, double y)
        {
            return Math.Round(x - y, 3);
        }

        public static double multiplicar(double x, double y)
        {
            return (x * y);
        }

        public static double Divisao(double x, double y)
        {
            return (x / y);
        }

        public static double Modular(double x)
        {
            return (0.5 * x);
        }

        public static double Potenciacao(double x)
        {
            return (x * x);
        }

        public static double Radiciação(double x)
        {
            return Math.Sqrt(x);
        }

    }
}
