using System.ComponentModel.DataAnnotations;

namespace InvestimentosApi.Models;

public class Carteira
{
    [Key]
    public int Id { get; set; }

    public int ContaId { get; set; }
    public string AtivoId { get; set; }
    public string TipoAtivo { get; set; } = "Ação";
    public int Quantidade { get; set; }
    public double ValorTotal { get; set; }

    public Carteira(int contaId, string ativoId, string tipoAtivo, int quantidade, double valorTotal)
    {
        ContaId = contaId;
        AtivoId = ativoId;
        TipoAtivo = tipoAtivo;
        Quantidade = quantidade;
        ValorTotal = valorTotal;
    }
}