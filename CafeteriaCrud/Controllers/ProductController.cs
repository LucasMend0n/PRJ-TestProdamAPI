using CafeteriaCrud.Db;
using CafeteriaCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CafeteriaCrud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public ProductController([FromServices] AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get() 
            => Ok(await _appDbContext.Products.AsNoTracking().ToListAsync());
        
        
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            Product product = await _appDbContext.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (product is null)
                return NotFound(ModelState);

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Post([FromBody] Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _appDbContext.Products.Add(product);
            await _appDbContext.SaveChangesAsync();
            return Ok(product);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Product>> Put([FromBody] Product product, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (product.Id != id)
                return NotFound(new { message = "ID incorreto" });

            try
            {
                _appDbContext.Products.Update(product);
                await _appDbContext.SaveChangesAsync();
                return Ok(product);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Não foi possivel atualizar produto!" });
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Product>> Delete(int id)
        {
            Product product = await _appDbContext.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (product is null)
                return NotFound(new { message = "Não encontrado!" });

            try
            {
                _appDbContext.Products.Remove(product);
                await _appDbContext.SaveChangesAsync();
                return Ok(new { message = "Produto deletado!" });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possivel remover o produto!" });
            }

        }
    }
}
