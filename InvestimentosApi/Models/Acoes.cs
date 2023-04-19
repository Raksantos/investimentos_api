using System.ComponentModel.DataAnnotations;

namespace InvestimentosApi.Models;

public class Acoes
{
    [Key]
    [Required]
    public string Id { get; set; }
    [Required(ErrorMessage = "O nome curto é obrigatório")]
    public string NomeCurto { get; set; }
    [Required(ErrorMessage = "O nome longo é obrigatório")]
    public string NomeLongo { get; set; }
    [Required(ErrorMessage = "A moeda é obrigatória")]
    public string MoedaUsada { get; set; }
    public double PrecoMercado { get; set; }

    public Acoes(string id, string nomeCurto, string nomeLongo, string moedaUsada, double precoMercado)
    {
        Id = id;
        NomeCurto = nomeCurto;
        NomeLongo = nomeLongo;
        MoedaUsada = moedaUsada;
        PrecoMercado = precoMercado;
    }
}