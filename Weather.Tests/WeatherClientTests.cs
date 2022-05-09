using NUnit.Framework;
using Weather.Library;
using Microsoft.Extensions.Configuration;
namespace Weather.Tests
{

    public class WeatherClientTests
    {
        WeatherClient client;
        private CurrentWeather currentWeather;
        private Main main;

        private Wind wind;
        private readonly decimal lat = 42.9892m;
        private readonly decimal lon = -78.745m;

        [SetUp]
        public async void Setup()
        {
            var builder = new ConfigurationBuilder().AddUserSecrets<WeatherClientTests>().Build();
            var apiKey = builder.GetValue<string>("apiKey").Split("=")[1];
            client = new WeatherClient(apiKey);
            currentWeather = await client.GetWeatherByCoordinatesAsync(lat, lon);
            main = currentWeather.Main;
            wind = currentWeather.Wind;
        }

        [Test]
        public void HttpCallReturnsProperObject()
        {
            //Arrange

            //Act
            var reply = client.GetWeatherByCoordinatesAsync(lat, lon);
            //Assert
            Assert.IsInstanceOf(typeof(CurrentWeather), reply);
        }
        [Test]
        [TestCase("Buffalo", "NY", "US")]
        public async void CanGetWeatherByCityStateAsync(string city, string state, string country)
        {
            //Arrange
            CurrentWeather weatherByCity;
            //Act
            weatherByCity = await client.GetWeatherByCityStateAsync(city, state, country);
            //Assert
            Assert.NotNull(weatherByCity);
        }

        [Test]
        public void Can_Request_Current_Weather()
        {
            //Arrange
            //Act

            //Assert
            Assert.NotNull(currentWeather);
        }
        [Test]
        public void Weather_Client_Can_Be_Instantiated()
        {
            Assert.NotNull(client);
        }

    }
}