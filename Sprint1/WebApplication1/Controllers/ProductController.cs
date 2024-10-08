﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using WebApplication1.Domains;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {
        private readonly IMongoCollection<Product> _product;

        public ProductController(MongoDbService service)
        {
            _product = service.GetDatabase.GetCollection<Product>("product");
        }

        [HttpGet]

        public async Task<ActionResult<List<Product>>> Get()
        {
            try
            {
                var products = await _product.Find(FilterDefinition<Product>.Empty).ToListAsync();
                return Ok(products);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]

        public async Task<ActionResult> Post(Product product)
        {
            try
            {
                await _product.InsertOneAsync(product);
                return Ok(product);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetByID")]
        public async Task<ActionResult> GetById(string id)
        {
            try
            {
                var lista = await _product.Find(Builders<Product>.Filter.Eq(m => m.Id, id)).ToListAsync();

                return lista is not null ? Ok(lista) : NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                await _product.DeleteOneAsync(Builders<Product>.Filter.Eq(m => m.Id, id));
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [HttpPut]
        public async Task<ActionResult> Put( Product p )
        {
            try
            {
               //buscar por id (filtro)
               var filter = Builders<Product>.Filter.Eq(x => x.Id, p.Id);

                if (filter != null)
                {
                    //substituindo o objeto buscado pelo novo produto
                    await _product.ReplaceOneAsync(filter, p);

                    return Ok();
                }
                
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
