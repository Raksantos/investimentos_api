using Microsoft.AspNetCore.Mvc;
using InvestimentosApi.Models;
using InvestimentosApi.Data;

namespace InvestimentosApi.Controllers;
[ApiController]
[Route("[controller]")]
public class AcoesController : ControllerBase
{
    private DatabaseCotext _context;
    public AcoesController(DatabaseCotext context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<Acoes> List([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _context.Acoes.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult? GetById(string id)
    {
        var acoes = _context.Acoes.FirstOrDefault(acoes => acoes.Id == id);
        if (acoes == null) return NotFound();
        return Ok(acoes);
    }
}