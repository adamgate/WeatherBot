using System;
using System.Collections.Generic;

namespace WeatherBot
{
    /**
     * <summary>
     * Handles calls to the OpenWeather API. 
     * </summary>
     */
    public class WeatherChecker
    {
        private string RootUrl = "https://api.openweathermap.org/data/3.0/";
        
        private List<string> Locations { get; set; }
        private Dictionary<string, string> Settings { get; set; }
        private string SettingsPath = "../../settings.json";
        private string ApiKey;
        private TimeZone TimeZone { get; set; }
        private DateTime LastSuccessfulRequest { get; set; }
        
        public WeatherChecker()
        {
            ReadSettings();
            LoadApiKey();
        }

        /**
         * <summary>
         * Entry point of the program.
         * </summary>
         */
        public string GetWeather()
        {
            //assemble query and return data
            return null;
        }

        private void LoadApiKey()
        {
            //read api key from file
        }

        private void ReadSettings()
        {
            //load settings from json file   
            /*
             * Settings:
             * time zone
             * 
             */
        }

        private void WriteSettings()
        {
            //write settings to file
        }
    }
}