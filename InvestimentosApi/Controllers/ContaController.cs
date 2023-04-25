using Microsoft.AspNetCore.Mvc;
using InvestimentosApi.Models;
using InvestimentosApi.Data;
using System.Text.Json;

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
        var conta = _context.Contas.FirstOrDefault(conta => conta.Id == id);
        if (conta == null) return NotFound();

        var elementosCarteira = _context.Carteiras.Where(carteira => carteira.ContaId == conta.Id);
        Console.WriteLine(elementosCarteira.Count());

        List<object> ativos = new List<object>();

        foreach (Carteira elemento in elementosCarteira)
        {
            ativos.Add(new { elemento.AtivoId, elemento.TipoAtivo, elemento.Quantidade, elemento.ValorTotal });
        }

        //serializa conta para um json
        var contaJson = JsonSerializer.Serialize(conta);
        
        //crie um novo campo chamado ativos e associei a lista de ativos a ele
        contaJson = contaJson.Insert(contaJson.Length - 1, $",\"ativos\":{JsonSerializer.Serialize(ativos)}");

        Console.WriteLine(contaJson);

        return Ok(contaJson);
    }

    [HttpPatch("{id}/valor/{valor}")]
    public IActionResult Deposita(int id, int valor)
    {   
        var conta = _context.Contas.FirstOrDefault(conta => conta.Id == id);
        Console.WriteLine("Conta" + conta);
        if (conta == null) return NotFound();
        conta.SaldoDisponivel += valor;
        _context.SaveChanges();
        return Ok(conta);
    }
}