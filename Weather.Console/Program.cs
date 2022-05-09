// See https://aka.ms/new-console-template for more information
using Weather.Library;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

InitializeClient();
Console.WriteLine("Welcome to TinyWeather\nAn Extremely Small Weather Program");
string input;
do
{
    Console.Write("'1' for weather by location\n'2' for weather by City, State\n'3' for weather by Zip Code\n'xx' to quit\nOption: ");
    input = Console.ReadLine();
    var result = PerformSearchAsync(input);
    Console.WriteLine(result.Result);
} while (input != "xx");
internal partial class Program
{
   
private static WeatherClient client;
private static string apiKey;



    public static async Task<string> PerformSearchAsync(string input)
    {
        string result = "";
        switch (input)
        {
            case "1":
                result = await SearchByCoordinatesAsync();
                //Console.WriteLine(result);
                break;
            case "2":
                result = await SearchByCityStateAsync();
                //Console.WriteLine(result);
                break;
            case "3":
                result = await SearchByZipCodeAsync();
                //Console.WriteLine(result);
                break;
        }
        //Console.Write("'1' for weather by location\n'2' for weather by City, State\n'3' for weather by Zip Code\n'xx' to quit\nOption: ");
        return result;
    }

    private static async Task<string> SearchByCoordinatesAsync()
    {
        //coordinate request formatted as: lat,lon so we split on the comma
        Console.Write("Enter 'lat,lon': ");
        var input = Console.ReadLine();
        var inputs = input.Split(",");
        decimal lat = decimal.Parse(inputs[0]);
        decimal lon = decimal.Parse(inputs[1]);
        var weather = await client.GetWeatherByCoordinatesAsync(lat, lon);
        return "\n" + weather.ToString();
    }

    private static async Task<string> SearchByCityStateAsync()
    {
        Console.Write("Enter 'City, State, Country': ");
        var inputs = Console.ReadLine().Split(",");
        string city = inputs[0];
        string state = inputs[1];
        string country = inputs[2];
        var weather = await client.GetWeatherByCityStateAsync(city, state, country);
        return weather.ToString();
    }
    private static async Task<string> SearchByZipCodeAsync()
    {
        Console.Write("Enter 'Zip, Country': ");
        var inputs = Console.ReadLine().Split(",");
        string zip = inputs[0];
        string country = inputs[1];
        var weather = await client.GetWeatherByZipCodeAsync(zip, country);
        return "\n" + weather.ToString();
    }
    public static void InitializeClient()
    {
        var builder = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
        apiKey = builder.GetValue<string>("apiKey").Split("=")[1];
        client = new WeatherClient(apiKey);
    }
}

