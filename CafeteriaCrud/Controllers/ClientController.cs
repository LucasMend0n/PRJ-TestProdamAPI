using CafeteriaCrud.Db;
using CafeteriaCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CafeteriaCrud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public ClientController([FromServices] AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Client>>> Get()
        {
            return Ok(await _appDbContext.Clients.AsNoTracking().ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Client>> GetById(int id)
        {
            Client client = await _appDbContext.Clients.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (client is null)
                return NotFound(ModelState);

            return Ok(client);
        }

        [HttpPost]
        public async Task<ActionResult<Client>> Post([FromBody] Client client)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _appDbContext.Clients.Add(client);
            await _appDbContext.SaveChangesAsync();
            return Ok(client);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Client>> Put([FromBody] Client client, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (client.Id != id)
                return NotFound(new { message = "ID incorreto" });

            try
            {
                _appDbContext.Clients.Update(client);
                await _appDbContext.SaveChangesAsync();
                return Ok(client);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Não foi possivel atualizar cliente!" });
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Client>> Delete(int id)
        {
            Client client = await _appDbContext.Clients.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (client is null)
                return NotFound(new { message = "Não encontrado!" });

            try
            {
                _appDbContext.Clients.Remove(client);
                await _appDbContext.SaveChangesAsync();
                return Ok(new { message = "Produto deletado!" });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possivel remover o cliente!" });
            }
        }
    }
}