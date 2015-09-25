using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TechEd.Core.Models;

namespace TechEd.Core.Services
{
    public static class ServicoClima
    {
        private const string Url = "http://api.openweathermap.org/data/2.5/weather?lat={0}&lon={1}";

        public static async Task<WeatherData> GetWeather(double lat, double lon)
        {
            var client = new HttpClient();
            var result = await client.GetAsync(string.Format(Url, lat, lon));
            return JsonConvert.DeserializeObject<WeatherData>(await result.Content.ReadAsStringAsync());
        }
    }
}
