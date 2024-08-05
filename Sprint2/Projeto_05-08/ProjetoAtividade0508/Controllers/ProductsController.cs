using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Projeto_Atividade_05_08.Domains;
using ProjetoAtividade0508.Interfaces;
using ProjetoAtividade0508.Repositories;

namespace ProjetoAtividade0508.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _product;

        public ProductsController()
        {
            _product = new ProductRepository();
        }

        [HttpPost]
        public IActionResult Post(Products p)
        {
            try
            {
                _product.Cadastrar(p);
                return Ok(p);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_product.ListarTodos());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("BuscarPorId")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_product.BuscarPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _product.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(Products m, Guid id)
        {
            try
            {
                _product.Atualizar(m, id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
