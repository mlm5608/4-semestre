using Projeto_Atividade_05_08.Domains;

namespace ProjetoAtividade0508.Interfaces
{
    public interface IProductRepository
    {
        public void Cadastrar(Products m);
        public List<Products> ListarTodos();
        public Products BuscarPorId(Guid id);
        public void Deletar(Guid id);
        public void Atualizar(Products m, Guid id);
    }
}
