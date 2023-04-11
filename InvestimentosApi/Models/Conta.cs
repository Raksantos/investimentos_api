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
    [MaxLength(11, ErrorMessage = "O CPF deve ter 11 caracteres")]
    public string CPF { get; set; }
    public string SaldoDisponivel { get; set; }
    public string SaldoInvestido { get; set; }
}