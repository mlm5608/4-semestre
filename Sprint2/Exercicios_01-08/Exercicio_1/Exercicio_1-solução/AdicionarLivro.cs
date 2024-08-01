using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_1_solução
{
    public class AdicionarLivro
    {
        public static List<Object> AdicionaLivros(int idLivro , string nomeLivro, string generoLivro)
        {
            List<Object> lista = new List<Object>();

            var livro = new
            {
                idLivro = idLivro,
                nomeLivro = nomeLivro,
                generoLivro = generoLivro
            };
            
            lista.Add(livro);

            return lista;
        }
    }
}
