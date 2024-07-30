using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using WebApplication1.Domains;
using WebApplication1.Services;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class OrderController : ControllerBase
    {
        private readonly IMongoCollection<Order> _order;
        private readonly IMongoCollection<Client> _client;
        private readonly IMongoCollection<Product> _product;

        public OrderController(MongoDbService service)
        {
            _order = service.GetDatabase.GetCollection<Order>("order");
            _client = service.GetDatabase.GetCollection<Client>("client");
            _product = service.GetDatabase.GetCollection<Product>("product");
        }

        [HttpGet]

        public async Task<ActionResult<List<Order>>> Get()
        {
            try
            {
                var orders = await _order.Find(FilterDefinition<Order>.Empty)
                    .ToListAsync();

                return Ok(orders);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]

        public async Task<ActionResult> Post(OrderViewModel orderV)
        {
            try
            {
                Order order = new Order();

                order.Id = orderV.Id;
                order.Date = orderV.Date;
                order.Status = orderV.Status;
                order.ProductIds = orderV.ProductIds;
                order.ClientId = orderV.ClientId;

                var client = await _client.Find(m => m.Id == order.ClientId).FirstOrDefaultAsync();
                if (client == null)
                {
                    return NotFound("Cliente não encontrado");
                }
                order.Client = client;

                List<Product> produtos = new List<Product>();
                var produtosBuscados = order.ProductIds;
                var ListaTodosProdutos = await _product.Find(FilterDefinition<Product>.Empty).ToListAsync();

                foreach(string Id in produtosBuscados!)
                {
                    foreach (Product p in ListaTodosProdutos)
                    {
                        if (Id == p.Id)
                        {
                            produtos.Add(p);
                        }
                    }
                }
                order.Products = produtos;

                await _order.InsertOneAsync(order);
                return Ok(order);
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
                var lista = await _order.Find(Builders<Order>.Filter.Eq(m => m.Id, id)).ToListAsync();

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
                await _order.DeleteOneAsync(Builders<Order>.Filter.Eq(m => m.Id, id));
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPut]
        public async Task<ActionResult> Put(Order o)
        {
            try
            {
                //buscar por id (filtro)
                var filter = Builders<Order>.Filter.Eq(x => x.Id, o.Id);

                if (filter != null)
                {
                    //substituindo o objeto buscado pelo novo produto
                    await _order.ReplaceOneAsync(filter, o);

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
