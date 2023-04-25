using System.ComponentModel.DataAnnotations;

namespace InvestimentosApi.Models;

public class Cripto
{
    [Key]
    [Required]
    public string ?Id { get; set; }
    [Required(ErrorMessage = "O nome é obrigatório")]
    public string ?Nome { get; set; }
    [Required]
    public string ?MoedaUsada { get; set; }
    [Required]
    public double PrecoMercado { get; set; }

    public Cripto(string ?id, string ?nome, string ?moedaUsada, double precoMercado)
    {
        Id = id;
        Nome = nome;
        MoedaUsada = moedaUsada;
        PrecoMercado = precoMercado;
    }
}