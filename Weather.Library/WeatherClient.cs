using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace Weather.Library
{
    public class WeatherClient
    {
        private readonly string apiKey;
        private readonly string baseCall = "https://api.openweathermap.org/data/2.5/weather?";
        private readonly HttpClient weatherClient;

        public WeatherClient(string apiKey)
        {
            this.apiKey = apiKey;
            weatherClient = new HttpClient();
        }

        public async Task<CurrentWeather> GetWeatherByCoordinatesAsync(decimal lat, decimal lon)
        {
            var url = BuildCoordinateUrl(lat, lon);
            var task = await weatherClient.GetStringAsync(url);
            var result = DeserializeResult(task);
            return result;
        }

        public async Task<CurrentWeather> GetWeatherByZipCodeAsync(string zip, string country)
        {
            var url = BuildZipCodeUrl(zip, country);
            var task = await weatherClient.GetStringAsync(url);
            var result = DeserializeResult(task);
            return result;
        }

        public async Task<CurrentWeather> GetWeatherByCityStateAsync(string city, string state, string country)
        {

            var url = BuildCityStateUrl(city, state, country);
            var task = await weatherClient.GetStringAsync(url);
            var result = DeserializeResult(task);
            return result;
        }
        private string BuildCoordinateUrl(decimal lat, decimal lon)
        {
            return baseCall + "lat=" + lat + "&lon=" + lon + "&units=imperial&appid=" + apiKey;
        }

        private string BuildCityStateUrl(string city, string state, string country)
        {
            return baseCall + "q=" + city + "," + state + "," + country + "&units=imperial&appid=" + apiKey;
        }
        private string BuildZipCodeUrl(string zip, string country)
        {
            return baseCall + "zip=" + zip + "," + country + "&units=imperial&appid=" + apiKey;
        }

        private static CurrentWeather DeserializeResult(string result)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var currentWeather = JsonSerializer.Deserialize<CurrentWeather>(result, options);
            return currentWeather;
        }

    }
}
