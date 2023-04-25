using System.ComponentModel.DataAnnotations;

namespace InvestimentosApi.Models;

public class Cripto : Ativo
{
    public Cripto(string id, string nomeCurto, string moedaUsada, double precoMercado) : base(id, nomeCurto, moedaUsada, precoMercado)
    {
    }
}