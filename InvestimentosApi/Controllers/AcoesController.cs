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

    [HttpPatch("{id_conta}/acao/{id_acao}/quantidade/{qtd}")]

    public IActionResult? Investir(int id_conta, string id_acao, int qtd){
        var conta = _context.Contas.FirstOrDefault(conta => conta.Id == id_conta);
        var acao = _context.Acoes.FirstOrDefault(acao => acao.Id == id_acao);
        
        if (conta == null || acao == null) return NotFound();
        if (conta.SaldoDisponivel < acao.PrecoMercado * qtd) return BadRequest();
        
        conta.SaldoDisponivel -= acao.PrecoMercado * qtd;

        conta.SaldoInvestido += acao.PrecoMercado * qtd;
        
        //verifica se a carteira já possui o ativo
        var carteira = _context.Carteiras.FirstOrDefault(carteira => carteira.ContaId == conta.Id && carteira.AtivoId == acao.Id);

        if (carteira != null){
            carteira.Quantidade += qtd;
            carteira.ValorTotal += acao.PrecoMercado * qtd;
        } else {
            carteira = new Carteira(conta.Id, acao.Id, "acao", qtd, acao.PrecoMercado * qtd);
            _context.Carteiras.Add(carteira);
        }

        _context.SaveChanges();
        return Ok(conta);
    }

    [HttpPatch("{id_conta}/acao/{id_acao}/quantidade/{qtd}/vender")]
    public IActionResult? Vender(int id_conta, string id_acao, int qtd){
        var conta = _context.Contas.FirstOrDefault(conta => conta.Id == id_conta);
        var acao = _context.Acoes.FirstOrDefault(acao => acao.Id == id_acao);
        
        if (conta == null || acao == null) return NotFound();
        
        //verifica se a carteira já possui o ativo
        var carteira = _context.Carteiras.FirstOrDefault(carteira => carteira.ContaId == conta.Id && carteira.AtivoId == acao.Id);

        if (carteira == null || carteira.Quantidade < qtd) return BadRequest();

        conta.SaldoDisponivel += acao.PrecoMercado * qtd;

        conta.SaldoInvestido -= acao.PrecoMercado * qtd;

        carteira.Quantidade -= qtd;
        carteira.ValorTotal -= acao.PrecoMercado * qtd;

        if (carteira.Quantidade == 0) _context.Carteiras.Remove(carteira);

        _context.SaveChanges();

        if (_context.Carteiras.Where(carteira => carteira.ContaId == conta.Id).Count() == 0) conta.SaldoInvestido = 0;

        return Ok(conta);
    }
}