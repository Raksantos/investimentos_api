using System.ComponentModel.DataAnnotations;

namespace InvestimentosApi.Models;

public class Ativo
{
    [Key]
    [Required]
    public string Id { get; set; }
    [Required(ErrorMessage = "O nome curto é obrigatório")]
    public string NomeCurto { get; set; }
    [Required(ErrorMessage = "O nome longo é obrigatório")]
    public string MoedaUsada { get; set; }
    public double PrecoMercado { get; set; }

    public Ativo(string id, string nomeCurto, string moedaUsada, double precoMercado)
    {
        Id = id;
        NomeCurto = nomeCurto;
        MoedaUsada = moedaUsada;
        PrecoMercado = precoMercado;
    }
}