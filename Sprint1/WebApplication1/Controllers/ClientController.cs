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
    public class ClientController : ControllerBase
    {
        private readonly IMongoCollection<Client> _client;

        public ClientController(MongoDbService service)
        {
            _client = service.GetDatabase.GetCollection<Client>("client");
        }

        [HttpGet]

        public async Task<ActionResult<List<Client>>> Get()
        {
            try
            {
                var clients = await _client.Find(FilterDefinition<Client>.Empty).ToListAsync();
                return Ok(clients);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]

        public async Task<ActionResult> Post(Client client)
        {
            try
            {
                await _client.InsertOneAsync(client);
                return Ok(client);
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
                var lista = await _client.Find(Builders<Client>.Filter.Eq(m => m.Id, id)).ToListAsync();

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
                await _client.DeleteOneAsync(Builders<Client>.Filter.Eq(m => m.Id, id));
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPut]
        public async Task<ActionResult> Put(Client c)
        {
            try
            {
                //buscar por id (filtro)
                var filter = Builders<Client>.Filter.Eq(x => x.Id, c.Id);

                if (filter != null)
                {
                    //substituindo o objeto buscado pelo novo produto
                    await _client.ReplaceOneAsync(filter, c);

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
