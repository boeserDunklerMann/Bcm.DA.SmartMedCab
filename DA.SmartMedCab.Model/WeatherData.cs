namespace DA.SmartMedCab.Model
{
	public class WeatherData
	{
		public int WeatherDataID { get; set; }
		public int LocationID { get; set; }
		public Location Location { get; set; }
        public DateTime? CreationDate { get; set; }
		public DateTime? DateTime {  get; set; }
		public int? WmoCode { get; set; }
        public int? Temp_2m { get; set; }
        public DateTime? ChangeDate { get; set; }
    }
}
