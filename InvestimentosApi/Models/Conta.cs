using System.ComponentModel.DataAnnotations;

namespace InvestimentosApi.Models;

public class Conta
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "O nome é obrigatório")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "O CPF é obrigatório")]
    [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}\-\d{2}$", ErrorMessage = "O CPF deve estar no formato 000.000.000-00")]
    public string CPF { get; set; }
    public double SaldoDisponivel { get; set; }
    public double SaldoInvestido { get; set; }
}