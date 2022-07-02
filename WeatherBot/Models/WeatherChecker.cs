using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherBot.Models
{
    /**
     * <summary>
     * Handles calls to the OpenWeather API. 
     * </summary>
     */
    public class WeatherChecker
    {
        private string RootUrl = "https://api.openweathermap.org/data/2.5/";
        private Location Location;
        private string ApiKey;

        public WeatherChecker(string location)
        {
            Location = new Location(location);
            LoadApiKey();
        }

        /**
         * <summary>
         * Queries OpenWeather API for the weather
         * </summary>
         * <returns>OpenWeather API response</returns>
         */
        public async Task<string> GetWeather()
        {
            HttpClient client = new HttpClient();
            string query = $"{RootUrl}weather?lat={41.258652}&lon={-95.937187}&appid={ApiKey}";
            string responseBody = await client.GetStringAsync(query);

            //assemble query and return data
            return responseBody;
        }

        private void LoadApiKey()
        {
            ApiKey = File.ReadAllText("../../apikey.txt");
        }
    }
}