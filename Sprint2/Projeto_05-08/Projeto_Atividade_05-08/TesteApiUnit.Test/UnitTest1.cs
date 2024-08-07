using Microsoft.AspNetCore.Authentication;
using Moq;
using Projeto_Atividade_05_08.Domains;
using ProjetoAtividade0508.Interfaces;
using ProjetoAtividade0508.Repositories;

namespace TesteApiUnit.Test
{
    public class TesteDeProducts
    {
        /// <summary>
        /// Teste para a funcuionalidade de listar todos os produtos
        /// </summary>

        //[Fact]
        public void Get()
        {
            //Arrange

            //Lista de produtos
            var products = new List<Products>
            {
                new Products{ IdProduct = Guid.NewGuid(), Name = "produto1", Price= 10 },
                new Products{ IdProduct = Guid.NewGuid(), Name = "produto2", Price= 15 },
                new Products{ IdProduct = Guid.NewGuid(), Name = "produto3", Price= 30 },
            };

            //cria um objeto de simulação do tipo ProductRepository
            var mockRepository = new Mock<IProductRepository>();

            //configura o metodo de listarTodos para que quando for acionado retorne a lista mockada
            mockRepository.Setup(x => x.ListarTodos()).Returns(products);

            //Act
            var result = mockRepository.Object.ListarTodos();

            //Assert
            Assert.Equal(3, result.Count());
        }

        //[Fact]
        public void Post()
        {
            var products = new List<Products>();

            var novoProduto = new Products { IdProduct = Guid.NewGuid(), Name = "Carro", Price= 100000 };

            var mockRepository = new Mock<IProductRepository>();

            mockRepository.Setup(x => x.Cadastrar(novoProduto)).Callback<Products>(x => products.Add(novoProduto));

            mockRepository.Object.Cadastrar(novoProduto);

            Assert.Contains(novoProduto, products);
        }

        [Fact]
        public void Delete()
        {
            var produtoparaapagar = new Products { IdProduct = Guid.Parse("0f8fad5b-d9cb-469f-a165-70867728950e"), Name = "produto1", Price = 10 };
            var products = new List<Products>
            {
                produtoparaapagar,
                new Products{ IdProduct = Guid.NewGuid() , Name = "produto2", Price= 20 }
            };

            

            var mockRepository = new Mock<IProductRepository>();

            mockRepository.Setup(x => x.Deletar(produtoparaapagar.IdProduct)).Callback(() => products.Remove(produtoparaapagar));

            mockRepository.Object.Deletar(produtoparaapagar.IdProduct);

            Assert.DoesNotContain(produtoparaapagar, products);

        }

        [Fact]
        public void GetById()
        {

            List<Products> productList = new List<Products>();


            Products product = new Products
            {
                IdProduct = Guid.NewGuid(),
                Name = "Óculos da Catarina",
                Price = 32
            };

            productList.Add(product);


            var productBuscado = productList.FirstOrDefault(x => x.IdProduct == product.IdProduct);


            var mockRepository = new Mock<IProductRepository>();

            mockRepository.Setup(x => x.BuscarPorId(product.IdProduct)).Returns(productBuscado);

            mockRepository.Object.BuscarPorId(product.IdProduct);

            Assert.Equal(1, productList.Count);
        }

        /// <summary>
        /// Teste para a funcionalidade de atualizar um produto
        /// </summary>
        [Fact]
        public void Put()
        {

            List<Products> productList = new List<Products>();


            Products product = new Products
            {
                IdProduct = Guid.NewGuid(),
                Name = "Óculos da Catarina",
                Price = 32
            };
            productList.Add(product);


            var mockRepository = new Mock<IProductRepository>();


            mockRepository.Setup(x => x.Atualizar(product, product.IdProduct)).Callback<Guid, Products>((id, p) =>
            {
                var item = productList.FirstOrDefault(x => x.IdProduct == id);

                if (item != null)
                {
                    p.Name = "Óculos do Matheus Lima";
                    p.Price = 35;
                    productList.Add(product);
                }
            });

            mockRepository.Object.Atualizar(product, product.IdProduct);

            Assert.Equal("Óculos do Matheus Lima", product.Name);
        }

    }
}
