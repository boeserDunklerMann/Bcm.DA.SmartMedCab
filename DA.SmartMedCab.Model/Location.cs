namespace DA.SmartMedCab.Model
{
	public class Location
	{
        public int LocationID { get; set; }
		public string? Name { get; set; }
        public decimal? Latitude { get; set; }
		public decimal? Longitude { get; set; }

		//public IList<WeatherData> WeatherData { get; set; }
    }
}
