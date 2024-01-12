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
			optionsBuilder.UseSqlServer("Server=.\\SQLExpress; Database=DA.SmartMedCab; Integrated Security=False; Encrypt=False;user=sa;Password=only4sus.1234");
		}
	}
}
