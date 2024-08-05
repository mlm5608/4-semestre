
using Projeto_Atividade_05_08.Domains;
using ProjetoAtividade0508.Contexts;
using ProjetoAtividade0508.Interfaces;

namespace ProjetoAtividade0508.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private yContext _context {  get; set; }

        public ProductRepository()
        {
            _context = new yContext();
        }
        public void Atualizar(Products prod, Guid id)
        {
            try
            {
                Products p = _context.Products.Find(id)!;
                if (p != null)
                {
                    p.Name = prod.Name;
                    p.Price = prod.Price;
                }
                _context.Products.Update(p!);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Products BuscarPorId(Guid id)
        {
            try
            {
                return _context.Products.FirstOrDefault(x => x.IdProduct == id)!;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void Cadastrar(Products p)
        {
            try
            {
                _context.Products.Add(p);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Products prod = _context.Products.Find(id)!;
                if (prod != null)
                {
                    _context.Remove(prod);
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Products> ListarTodos()
        {
            try
            {
                return _context.Products.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
