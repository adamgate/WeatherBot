using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeatherBot.Models
{
    //Root class from OpenWeather JSON
    
    [JsonObject("main")]
    public class Temp
    {
        [JsonProperty("temp")]
        public double MainTemp { get; set; }
        
        [JsonProperty("feels_like")]
        public double FeelsLike { get; set; }
        
        [JsonProperty("temp_min")]
        public double MinTemp { get; set; }
        
        [JsonProperty("temp_max")]
        public double MaxTemp { get; set; }
        
        [JsonProperty("pressure")]
        public int Pressure { get; set; }
        
        [JsonProperty("humidity")]
        public int Humidity { get; set; }
    }

    public class WeatherReport
    {
        public List<Sky> Weather { get; set; }
        public Temp Main { get; set; }
        public Daylight Sys { get; set; }
    }

    [JsonObject("sys")]
    public class Daylight
    {
        [JsonProperty("sunrise")]
        public int Sunrise { get; set; }
        
        [JsonProperty("sunset")]
        public int Sunset { get; set; }
    }

    [JsonObject("weather")]
    public class Sky
    {
        [JsonProperty("main")]
        public string TerseSky { get; set; }
        
        [JsonProperty("description")]
        public string VerboseSky { get; set; }
    }
}