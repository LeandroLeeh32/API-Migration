
using learn_migration.Infrastructure.DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace learn_migration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogadorController : Controller
    {

        private readonly _DbContext _context;

        public JogadorController(_DbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.TbJogadors.ToListAsync());
        }
    }
}
