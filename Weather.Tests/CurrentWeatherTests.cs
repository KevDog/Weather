using NUnit.Framework;
using Weather.Library;
using System.Text.Json;

namespace Weather.Tests
{
    public class CurrentWeatherTests
    {
        readonly string result = "{\"coord\":{\"lon\":-78.745,\"lat\":42.9892},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01n\"}],\"base\":\"stations\",\"main\":{\"temp\":39.92,\"feels_like\":36.12,\"temp_min\":35.13,\"temp_max\":44.11,\"pressure\":1017,\"humidity\":67},\"visibility\":10000,\"wind\":{\"speed\":5.35,\"deg\":80,\"gust\":11.14},\"clouds\":{\"all\":0},\"dt\":1651985832,\"sys\":{\"type\":2,\"id\":2004821,\"country\":\"US\",\"sunrise\":1652003981,\"sunset\":1652055795},\"timezone\":-14400,\"id\":5144588,\"name\":\"Williamsville\",\"cod\":200}";
        CurrentWeather currentWeather;
        Coord coord;
        Main main;
        [SetUp]
        public void SetUp()
        {
            //TODO: make sure the current weather client has case insensitivty as well.
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            currentWeather = JsonSerializer.Deserialize<CurrentWeather>(result, options);
            main = currentWeather.Main;
            coord = currentWeather.Coord;
        }
        [Test]
        public void CanProperlyDeserializeWeatherHeader()
        {
            //Assert
            Assert.AreEqual("Williamsville", currentWeather.Name);
        }
        [Test]
        public void CanProperlyDeserializeCoordinates()
        {
            Assert.AreEqual(42.9892, coord.Lat);
            Assert.AreEqual(-78.745, coord.Lon);
        }

        [Test]
        public void CanProperlyDeserializeCurrentWeather()
        {
            Assert.AreEqual(39.92, main.Temp);
            Assert.AreEqual(36.12, main.Feels_like);
        }
    }
}