using System.ComponentModel.DataAnnotations;

namespace InvestimentosApi.Models;

public class Acoes : Ativo
{   
    [Required(ErrorMessage = "A moeda é obrigatória")]
    public string NomeLongo { get; set; }
    public Acoes(string id, string nomeCurto, string nomeLongo, string moedaUsada, double precoMercado) : base(id, nomeCurto, moedaUsada, precoMercado)
    {
        NomeLongo = nomeLongo;
    }
}