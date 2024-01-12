using DA.SmartMedCab.Model;
using Newtonsoft.Json.Linq;

namespace DA.SmartMedCab.Processes
{
	public class ForecastProcess : IProcess
	{
		public string Name => nameof(ForecastProcess);

		/// <summary>
		/// Das ist exakt, was ich brauche! -DA
		/// See also: https://geocoding-api.open-meteo.com/v1/search?name=leipzig&count=10&language=de&format=json
		/// </summary>
		/// <returns></returns>
		private static async Task<Forecast> OpenMeteoAsync()
		{
			var client = new HttpClient();
			var request = new HttpRequestMessage(HttpMethod.Get, "https://api.open-meteo.com/v1/dwd-icon?latitude=51.3396&longitude=12.3713&daily=weathercode&timezone=auto");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			string json = await response.Content.ReadAsStringAsync();
			Console.WriteLine(json);
			JObject o = JObject.Parse(json);
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8603
			JToken daily = o.SelectToken("daily");
			var forecast = daily?.ToObject<Forecast>();
			return forecast;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8603
		}

		public async Task RunAsync()
		{
			var fc = await OpenMeteoAsync();
			using (ModelContext ctx = new ModelContext())
			{
				var loc = ctx.Locations.FirstOrDefault(l => l.Name == "Leipzig");
				if (loc == null)
				{
					throw new Exception("Location not found");
				}
				if (fc.weathercode != null && fc.time != null)
					for (int i = 0; i < fc.weathercode.Length; i++)
					{
						WeatherData wd = new WeatherData() { CreationDate = DateTime.Now, WmoCode = fc.weathercode[i], DateTime = DateTime.Parse(fc.time[i]), ChangeDate = DateTime.Now };
						wd.Location = loc;
						ctx.WeatherData.Add(wd);
					}
				ctx.SaveChanges();
			}
		}
	}
}
