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
    public class UserController : ControllerBase
    {
        private readonly IMongoCollection<User> _user;

        public UserController(MongoDbService service)
        {
            _user = service.GetDatabase.GetCollection<User>("user");
        }

        [HttpGet]

        public async Task<ActionResult<List<User>>> Get()
        {
            try
            {
                var users = await _user.Find(FilterDefinition<User>.Empty).ToListAsync();
                return Ok(users);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]

        public async Task<ActionResult> Post(User user)
        {
            try
            {
                await _user.InsertOneAsync(user);
                return Ok(user);
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
                var lista = await _user.Find(Builders<User>.Filter.Eq(m => m.Id, id)).ToListAsync();

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
                await _user.DeleteOneAsync(Builders<User>.Filter.Eq(m => m.Id, id));
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPut]
        public async Task<ActionResult> Put(User u)
        {
            try
            {
                //buscar por id (filtro)
                var filter = Builders<User>.Filter.Eq(x => x.Id, u.Id);

                if (filter != null)
                {
                    //substituindo o objeto buscado pelo novo produto
                    await _user.ReplaceOneAsync(filter, u);

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
