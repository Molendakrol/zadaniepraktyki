using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Podaj kwotę w PLN"); 
        string input = Console.ReadLine();
        decimal kwotaPLN = decimal.Parse(input);
        decimal kursUSD = await PobierzKursUSD();
        decimal kwotaUSD = kwotaPLN / kursUSD;

        Console.WriteLine($"Aktualny kurs USD: {kursUSD}");
        Console.WriteLine($"Kwota {kwotaPLN} PLN to {kwotaUSD:F2} USD");
    }

    static async Task<decimal> PobierzKursUSD()
    {
        using var http = new HttpClient();
        string url = "https://api.nbp.pl/api/exchangerates/rates/a/usd/?format=json";
        string json = await http.GetStringAsync(url);

        using var doc = JsonDocument.Parse(json);
        var root = doc.RootElement;
        decimal kurs = root.GetProperty("rates")[0].GetProperty("mid").GetDecimal();

        return kurs;
    }
}
