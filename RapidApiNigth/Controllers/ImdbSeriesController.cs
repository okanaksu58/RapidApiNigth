using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiNigth.Models;

namespace RapidApiNigth.Controllers
{
    public class ImdbSeriesController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/series/"),
                Headers =
    {
        { "X-RapidAPI-Key", "c8de957553mshf1f6c4611cb197bp1849e8jsn10e0418ee477" },
        { "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ImdbSeriesViewModel>>(body);
                return View(values);
            }

        }
    }
}
