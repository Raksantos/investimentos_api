using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace StockQuoteExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string symbol = "PETR4";

            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), $"https://brapi.dev/api/quote/{symbol}"))
                {
                    var response = await httpClient.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var data = JObject.Parse(json);

                        Console.WriteLine($"Símbolo: {data["results"][0]["symbol"]}");
                        Console.WriteLine($"Nome curto: {data["results"][0]["shortName"]}");
                        Console.WriteLine($"Nome longo: {data["results"][0]["longName"]}");
                        Console.WriteLine($"Moeda: {data["results"][0]["currency"]}");
                        Console.WriteLine($"Preço médio de mercado: {data["results"][0]["regularMarketPrice"]}");
                        Console.WriteLine($"Alta do dia: {data["results"][0]["regularMarketDayHigh"]}");
                        Console.WriteLine($"Baixa do dia: {data["results"][0]["regularMarketDayLow"]}");
                    }
                    else
                    {
                        Console.WriteLine($"Erro ao obter cotação da ação {symbol}: {response.StatusCode}");
                    }
                }
            }
        }
    }
}