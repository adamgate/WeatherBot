using System;

namespace WeatherBot
{
    public class Location : IFormattable
    {
        private string Name { get; set; }
        private Tuple<float, float> Coordinates { get; set; }

        public Location(string name)
        {
            this.Name = name;
            NameToCoordinates();
        }
        
        private void NameToCoordinates()
        {
            //convert name to coordinates
        }
            
        public string ToString(string format, IFormatProvider formatProvider)
        {
            throw new NotImplementedException();
        }
    }
}