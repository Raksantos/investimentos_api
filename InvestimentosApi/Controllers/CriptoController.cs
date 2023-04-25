using Microsoft.AspNetCore.Mvc;
using InvestimentosApi.Models;
using InvestimentosApi.Data;

namespace InvestimentosApi.Controllers;
[ApiController]
[Route("[controller]")]
public class CriptoController : ControllerBase
{
    private DatabaseCotext _context;
    public CriptoController(DatabaseCotext context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<Cripto> List([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _context.Criptos.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult? GetById(string id)
    {
        var Criptos = _context.Criptos.FirstOrDefault(Criptos => Criptos.Id == id);
        if (Criptos == null) return NotFound();
        return Ok(Criptos);
    }
}