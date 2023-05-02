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

    [HttpPatch("{id_conta}/cripto/{id_cripto}/quantidade/{qtd}")]

    public IActionResult? Investir(int id_conta, string id_cripto, int qtd){
        var conta = _context.Contas.FirstOrDefault(conta => conta.Id == id_conta);
        var cripto = _context.Criptos.FirstOrDefault(cripto => cripto.Id == id_cripto);
        
        if (conta == null || cripto == null) return NotFound();
        if (conta.SaldoDisponivel < cripto.PrecoMercado * qtd) return BadRequest();
        
        conta.SaldoDisponivel -= cripto.PrecoMercado * qtd;

        conta.SaldoInvestido += cripto.PrecoMercado * qtd;
        
        //verifica se a carteira já possui o ativo
        var carteira = _context.Carteiras.FirstOrDefault(carteira => carteira.ContaId == conta.Id && carteira.AtivoId == cripto.Id);

        if (carteira != null){
            carteira.Quantidade += qtd;
            carteira.ValorTotal += cripto.PrecoMercado * qtd;
        } else {
            carteira = new Carteira(conta.Id, cripto.Id, "cripto", qtd, cripto.PrecoMercado * qtd);
            _context.Carteiras.Add(carteira);
        }

        _context.SaveChanges();
        return Ok(conta);
    }

    [HttpPatch("{id_conta}/cripto/{id_cripto}/quantidade/{qtd}/vender")]

    public IActionResult? Vender(int id_conta, string id_cripto, int qtd){
        var conta = _context.Contas.FirstOrDefault(conta => conta.Id == id_conta);
        var cripto = _context.Criptos.FirstOrDefault(cripto => cripto.Id == id_cripto);
        
        if (conta == null || cripto == null) return NotFound();
        if (conta.SaldoDisponivel < cripto.PrecoMercado * qtd) return BadRequest();
        
        conta.SaldoDisponivel += cripto.PrecoMercado * qtd;

        conta.SaldoInvestido -= cripto.PrecoMercado * qtd;
        
        //verifica se a carteira já possui o ativo
        var carteira = _context.Carteiras.FirstOrDefault(carteira => carteira.ContaId == conta.Id && carteira.AtivoId == cripto.Id);

        if (carteira != null){
            carteira.Quantidade -= qtd;
            carteira.ValorTotal -= cripto.PrecoMercado * qtd;
        } else {
            carteira = new Carteira(conta.Id, cripto.Id, "cripto", qtd, cripto.PrecoMercado * qtd);
            _context.Carteiras.Add(carteira);
        }

        if (carteira.Quantidade == 0) _context.Carteiras.Remove(carteira);

        _context.SaveChanges();
        return Ok(conta);
    }
}