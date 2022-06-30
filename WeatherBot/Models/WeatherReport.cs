using System.Collections.Generic;

namespace WeatherBot.Models
{
    //Root class from OpenWeather JSON
    public class WeatherReport
    {
        public List<Weather> Weather { get; }
        public Main Main { get; }
        public int Visibility { get; }
        public Wind Wind { get; }
        public Sys Sys { get; }
        public int Timezone { get; }

    }

    public class Main
    {
        public double Temp { get; }
        public double FeelsLike { get; }
        public double TempMin { get; }
        public double TempMax { get; }
        public int Pressue { get; }
        public int Humidity { get; }
    }

    public class Sys
    {
        public int Sunrise { get; }
        public int Sunset { get; }
    }

    public class Weather
    {
        public string Main { get; }
        public string Description { get; }
    }

    public class Wind
    {
        public double speed { get; }
        public int deg { get; }
        public double gust { get; }
    }
}