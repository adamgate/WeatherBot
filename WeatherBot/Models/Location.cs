namespace WeatherBot.Models
{
    public class Location
    {
        private string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Location(string name)
        {
            Name = name;
            NameToCoordinates();
        }
        
        private void NameToCoordinates()
        {
            
        }
    }
}