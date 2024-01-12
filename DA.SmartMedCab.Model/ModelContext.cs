using DA.SmartMedCab.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.SmartMedCab.Model
{
	public class ModelContext:DbContext
	{
		public DbSet<Location> Locations { get; set; }
		public DbSet<WeatherData> WeatherData { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseMySQL("Server=localhost;Database=DA_SmartMedCab;Uid=DA.SmartMedCab;Pwd=SmartMedCab.240112;Allow User Variables=true");
		}
	}
}
