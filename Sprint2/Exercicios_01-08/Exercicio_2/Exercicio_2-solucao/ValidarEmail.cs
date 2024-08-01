using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_2_solucao
{
    public class ValidarEmail
    {
        public static bool Validacao(string email)
        { 

            if ((email.Contains("@")) && (email.Contains(".")))
            {
                return true;
            }

            return false;
        }
    }
}
