using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace _1_lab_Finance_converter_Surovtsev
{
    internal class PrivatBankAPI : CurrencyAPI
    {   private const string Url = "https://api.privatbank.ua/p24api/pubinfo?exchange&coursid=5";

    public override string[] GetDollar()
    {
        var task = GetCurrency("USD");
        task.Wait();
        return task.Result;
    }

    public override string[] GetEuro()
    {
        var task = GetCurrency("EUR");
        task.Wait();
        return task.Result;
    }

    public override string[] GetRuble()
    {
        return new string[] { "Недоступно", "Недоступно" };  
    }

    private async Task<string[]> GetCurrency(string currencyCode)
    {
        try
        {
            using var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(Url);

            var currencies = JsonConvert.DeserializeObject<CurrencyData[]>(json);

            foreach (var currency in currencies)
            {
                if (currency.ccy == currencyCode)
                {
                    return new string[] { currency.buy, currency.sale };
                }
            }
            return new string[] { "N/A", "N/A" };
        }
        catch
        {
            return new string[] { "Помилка", "Помилка" };
        }
    }
}

class CurrencyData
{
    public string ccy { get; set; }   // Валюта (USD, EUR)
    public string base_ccy { get; set; }  // Базова валюта (зазвичай UAH)
    public string buy { get; set; }   // Курс покупки
    public string sale { get; set; }  // Курс продажу
}
}