using System.ComponentModel.DataAnnotations;

namespace InvestimentosApi.Models;

public class TesouroDireto
{
    [Key]
    [Required]
    public string ?Id { get; set; }
    public double PrecoMercado { get; set; }

    public TesouroDireto(string id, double precoMercado)
    {
        Id = id;
        PrecoMercado = precoMercado;
    }
}