using Microsoft.AspNetCore.Mvc;
using InvestimentosApi.Models;
using InvestimentosApi.Data;

namespace InvestimentosApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContaController : ControllerBase
    {
        private ContaContext _context;
        public ContaController(ContaContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Create([FromBody] Conta conta)
        {
            _context.Contas.Add(conta);
            return CreatedAtAction(nameof(GetById), new { id = conta.Id }, conta);
        }

        [HttpGet]
        public IEnumerable<Conta> List([FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            return _context.Contas.Skip(skip).Take(take);
        }

        [HttpGet("{id}")]
        public IActionResult? GetById(int id)
        {
            var conta = _context.Contas.FirstOrDefault(conta => conta.Id == id);
            if (conta == null) return NotFound();
            return Ok(conta);
        }
    }
}