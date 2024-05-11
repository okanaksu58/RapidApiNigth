using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiNigth.Models;

namespace RapidApiNigth.Controllers
{
    public class ExchanceController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=USD&to_symbol=TRY&language=en"),
                Headers =
    {
        { "X-RapidAPI-Key", "c8de957553mshf1f6c4611cb197bp1849e8jsn10e0418ee477" },
        { "X-RapidAPI-Host", "real-time-finance-data.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ExchancesViewModel>(body);
                return View(values);
            }
            
        }
    }
}
