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
        public List<Weather> Weather { get; set; }
        
        public Temp Main { get; set; }
        public int Visibility { get; set; }
        public int Dt { get; set; }
        public Sys Sys { get; set; }
        public int Timezone { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }
    }

    public class Sys
    {
        [JsonProperty("sunrise")]
        public int Sunrise { get; set; }
        
        [JsonProperty("sunset")]
        public int Sunset { get; set; }
    }

    public class Weather
    {
        [JsonProperty("main")]
        public string TerseSky { get; set; }
        
        [JsonProperty("description")]
        public string VerboseSky { get; set; }
    }
}