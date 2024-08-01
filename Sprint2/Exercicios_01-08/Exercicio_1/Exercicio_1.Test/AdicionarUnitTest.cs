using Exercicio_1_solução;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_1.Test
{
    public class AdicionarUnitTest
    {
        [Fact]
        public void VerificaAAdicaoLivro()
        {
            var id = 1;
            var nome = "Harry Potter e as Reliquias da Morte";
            var genero = "Fantasia";

            var listaGerada = AdicionarLivro.AdicionaLivros(id, nome, genero);

            Assert.NotEqual(0, listaGerada.Count);
        }
    }
}
