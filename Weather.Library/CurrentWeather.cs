using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Weather.Library
{

    public class CurrentWeather
    {
        public Coord Coord { get; set; }
        public Main Main { get; set; }
        public Wind Wind { get; set; }
        public int Timezone { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("Weather for: " + Name + "\n");
            builder.Append(Main.ToString());
            builder.Append(Wind.ToString());

            return builder.ToString();
        }
    }
    public class Main
    {

        public decimal Temp { get; set; }
        public decimal Feels_like { get; set; }
        public decimal Temp_min { get; set; }
        public decimal Temp_max { get; set; }
        public decimal Pressure { get; set; }
        public decimal Humidity { get; set; }

        public override string ToString()
        {
            var response = "The temperature is: " + Temp + " but it feels like: " + Feels_like +
                        ".\nAtmospheric pressure is: " + Pressure + " and the humidity is: " + Humidity + "\n" +
                        "Low temperature for today is: " + Temp_min + " and the high is: " + Temp_max;
            return response;
        }
    }
    public class Coord
    {

        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
    }

}