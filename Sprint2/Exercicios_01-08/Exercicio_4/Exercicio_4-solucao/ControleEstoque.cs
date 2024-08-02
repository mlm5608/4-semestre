using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_4_solucao
{
    public class ControleEstoque
    {
        
        public static List<ProdutoDomain> AdicionarProduto(string nome, int quantidade)
        {
            List<ProdutoDomain> products = new List<ProdutoDomain>
            {
                new ProdutoDomain{Name = "notebook", Quantity = 10 },
                new ProdutoDomain{Name = "celular", Quantity = 25 },
                new ProdutoDomain{Name = "fone de ouvido", Quantity = 50 }
            };

            foreach (var p in products)
            {
                if (p.Name == nome)
                {
                    p.Quantity = p.Quantity + quantidade;
                    return products;
                }
            }

            ProdutoDomain produtoNovo = new ProdutoDomain()
            {
                Name = nome,
                Quantity = quantidade
            };

            products.Add(produtoNovo);

            return products;
        }

        public static Object BuscarPeloNome(string nome)
        {
            List<ProdutoDomain> products = new List<ProdutoDomain>
            {
                new ProdutoDomain{Name = "notebook", Quantity = 10 },
                new ProdutoDomain{Name = "celular", Quantity = 25 },
                new ProdutoDomain{Name = "fone de ouvido", Quantity = 50 }
            };

            foreach (var p in products)
            {
                if (p.Name == nome)
                {
                    return p;
                }
            }

            object vazio = new Object();

            return vazio;
        }


    }
}
