using Microsoft.AspNetCore.Mvc;
using InvestimentosApi.Models;
using InvestimentosApi.Data;

namespace InvestimentosApi.Controllers;
[ApiController]
[Route("[controller]")]

public class TesouroDiretoController : ControllerBase
{
    private DatabaseCotext _context;
    public TesouroDiretoController(DatabaseCotext context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<TesouroDireto> List([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _context.TesouroDiretos.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult? GetById(string id)
    {
        var TesouroDiretos = _context.TesouroDiretos.FirstOrDefault(TesouroDiretos => TesouroDiretos.Id == id);
        if (TesouroDiretos == null) return NotFound();
        return Ok(TesouroDiretos);
    }

    [HttpPatch("{id_conta}/tesouro/{id_tesouro}/quantidade/{qtd}")]

    public IActionResult? Investir(int id_conta, string id_tesouro, int qtd){
        var conta = _context.Contas.FirstOrDefault(conta => conta.Id == id_conta);
        var tesouro = _context.TesouroDiretos.FirstOrDefault(tesouro => tesouro.Id == id_tesouro);
        
        if (conta == null || tesouro == null) return NotFound();
        if (conta.SaldoDisponivel < tesouro.PrecoMercado * qtd) return BadRequest();
        
        conta.SaldoDisponivel -= tesouro.PrecoMercado * qtd;

        conta.SaldoInvestido += tesouro.PrecoMercado * qtd;
        
        //verifica se a carteira já possui o ativo
        var carteira = _context.Carteiras.FirstOrDefault(carteira => carteira.ContaId == conta.Id && carteira.AtivoId == tesouro.Id);

        if (carteira != null){
            carteira.Quantidade += qtd;
            carteira.ValorTotal += tesouro.PrecoMercado * qtd;
        } else {
            carteira = new Carteira(conta.Id, tesouro.Id, "tesouro", qtd, tesouro.PrecoMercado * qtd);
            _context.Carteiras.Add(carteira);
        }

        _context.SaveChanges();
        return Ok(conta);
    }

    [HttpPatch("{id_conta}/tesouro/{id_tesouro}/quantidade/{qtd}/vender")]

    public IActionResult? Vender(int id_conta, string id_tesouro, int qtd){
        var conta = _context.Contas.FirstOrDefault(conta => conta.Id == id_conta);
        var tesouro = _context.TesouroDiretos.FirstOrDefault(tesouro => tesouro.Id == id_tesouro);
        
        if (conta == null || tesouro == null) return NotFound();
        if (conta.SaldoInvestido < tesouro.PrecoMercado * qtd) return BadRequest();
        
        conta.SaldoDisponivel += tesouro.PrecoMercado * qtd;

        conta.SaldoInvestido -= tesouro.PrecoMercado * qtd;
        
        //verifica se a carteira já possui o ativo
        var carteira = _context.Carteiras.FirstOrDefault(carteira => carteira.ContaId == conta.Id && carteira.AtivoId == tesouro.Id);

        if (carteira != null){
            carteira.Quantidade -= qtd;
            carteira.ValorTotal -= tesouro.PrecoMercado * qtd;
        } else {
            carteira = new Carteira(conta.Id, tesouro.Id, "tesouro", qtd, tesouro.PrecoMercado * qtd);
            _context.Carteiras.Add(carteira);
        }

        if (carteira.Quantidade == 0) _context.Carteiras.Remove(carteira);

        _context.SaveChanges();
        return Ok(conta);
    }
}