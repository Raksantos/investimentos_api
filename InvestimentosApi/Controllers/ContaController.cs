using Microsoft.AspNetCore.Mvc;
using InvestimentosApi.Models;
using InvestimentosApi.Data;

namespace InvestimentosApi.Controllers;
[ApiController]
[Route("[controller]")]
public class ContaController : ControllerBase
{
    private DatabaseCotext _context;
    public ContaController(DatabaseCotext context)
    {
        _context = context;
    }
    [HttpPost]
    public IActionResult Create([FromBody] Conta conta)
    {
        if (conta != null)
        {
            _context.Contas.Add(conta as Conta);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = conta.Id }, conta);
        }
        return BadRequest();
    }

    [HttpGet("{id}")]
    public IActionResult? GetById(int id)
    {
        Console.Write(id);
        var conta = _context.Contas.FirstOrDefault(conta => conta.Id == id);
        if (conta == null) return NotFound();
        return Ok(conta);
    }
}