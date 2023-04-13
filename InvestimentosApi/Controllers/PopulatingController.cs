using Microsoft.AspNetCore.Mvc;
using InvestimentosApi.Models;
using InvestimentosApi.Data;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace InvestimentosApi.Controllers;
[ApiController]
[Route("[controller]")]
public class PopulatingController : ControllerBase
{
    private DatabaseCotext _context;
    public PopulatingController(DatabaseCotext context)
    {
        _context = context;
    }
    [HttpPost]
    public async Task<IActionResult> CreateAsync()
    {
        //cria uma lista com os síbolos das ações
        List<string> ativos = new List<string> {"PETR4", "MGLU3"};

        var httpClient = new HttpClient();

        //percorre a lista de símbolos
        foreach (string ativo in ativos){
            var request = new HttpRequestMessage(new HttpMethod("GET"), $"https://brapi.dev/api/quote/{ativo}");
            var response = await httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var data = JObject.Parse(json);

                if (data["results"]?[0]?["regularMarketPrice"]?.ToString() != null)
                {
                    string symbol = data["results"]?[0]?["symbol"]?.ToString() ?? "";
                    var acao = _context.Acoes.FirstOrDefault(acoes => acoes.Id == symbol);

                    if (acao == null)
                    {
                        Console.WriteLine($"Símbolo: {data["results"]?[0]?["symbol"]}");
                        Console.WriteLine($"Nome curto: {data["results"]?[0]?["shortName"]}");
                        Console.WriteLine($"Nome longo: {data["results"]?[0]?["longName"]}");
                        Console.WriteLine($"Moeda: {data["results"]?[0]?["currency"]}");
                        Console.WriteLine($"Preço médio de mercado: {data["results"]?[0]?["regularMarketPrice"]}");

                        Acoes acaoInserir = new Acoes(
                            data["results"]?[0]?["symbol"]?.ToString() ?? "",
                            data["results"]?[0]?["shortName"]?.ToString() ?? "",
                            data["results"]?[0]?["longName"]?.ToString() ?? "",
                            data["results"]?[0]?["currency"]?.ToString() ?? "",
                            Convert.ToDouble(data["results"]?[0]?["regularMarketPrice"]?.ToString())
                        );

                        _context.Acoes.Add(acaoInserir);
                        _context.SaveChanges();
                    }
                }
            }
            else
            {
                Console.WriteLine($"Erro ao obter cotação da ação {ativo}: {response.StatusCode}");
            }
        }

        return Ok("Banco populado com sucesso");
    }
}