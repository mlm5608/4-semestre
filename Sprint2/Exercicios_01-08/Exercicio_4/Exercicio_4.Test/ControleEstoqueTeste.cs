using Exercicio_4_solucao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_4.Test
{
    public class ControleEstoqueTeste
    {
        [Theory]
        [InlineData("notebook", 5, false)]
        [InlineData("mouse", 20, true)]
        public void AdicionaProdutoAoEstoque(string nome, int quant, bool produtoN)
        {
            if (produtoN)
            {
                var listaP = ControleEstoque.AdicionarProduto(nome, quant);
                ProdutoDomain p = new ProdutoDomain
                {
                    Name = nome,
                    Quantity = quant,
                };

                bool cantem = listaP.Contains(p);
                Assert.True(cantem);    
            }
            else
            {
                var listaP = ControleEstoque.AdicionarProduto(nome, quant);
                var quantidadeT = 15;

                foreach (var produto in listaP)
                {
                    if (produto.Name == nome)
                    {
                        Assert.Equal(quantidadeT, quant);
                    }
                }


            }
        }

        [Fact]
        public void BuscaPeloNomeNaLista() 
        {
            ProdutoDomain p = new ProdutoDomain
            {
                Name = "notebook",
                Quantity = 10,
            };

            var produtoBuscado = ControleEstoque.BuscarPeloNome(p.Name);

            Assert.Equal(p, produtoBuscado);
        }
    }
}
