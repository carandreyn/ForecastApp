using ForecastApp.OpenWeatherMapModels;
using ForecastApp.Config;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Constants = ForecastApp.Config.Constants;

namespace ForecastApp.Repositories
{
    public class ForecastRepository : IForecastRepository
    {
        public WeatherResponse GetForecast(string city)
        {
            string IDOWeather = Constants.OPEN_WEATHER_APPID;
            var client = new HttpClient();
            var weatherURL = $"http://api.openweathermap.org/data/2.5/weather?q={city}&units=imperial&appid={IDOWeather}";

            try
            {
                var response = client.GetStringAsync(weatherURL).Result;

                // Deserialize the string content into JToken object
                var content = JsonConvert.DeserializeObject<WeatherResponse>(response);

                return content;

            }
            catch { return null; }

        }
    }
}
