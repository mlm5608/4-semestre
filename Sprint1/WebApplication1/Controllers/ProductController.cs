using Microsoft.AspNetCore.Http;
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
                var lista = await _product.Find(Builders<Product>.Filter.Eq(m => m.Id, id).ToListAsync()
                return Ok(lista);
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
        public async Task<ActionResult> Put(Product p, string id)
        {
            try
            {
                p.Id = id;
                await _product.FindOneAndReplaceAsync(Builders<Product>.Filter.Eq(m => m.Id, id), p);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
