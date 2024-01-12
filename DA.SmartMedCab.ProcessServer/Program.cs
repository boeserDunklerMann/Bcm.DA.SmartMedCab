using Hangfire;
using Hangfire.MySql;
using System.Transactions;

namespace DA.SmartMedCab.ProcessServer
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			string? connectionString = builder.Configuration.GetConnectionString("HangfireDB");
			builder.Services.AddHangfire(configuration => configuration.SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
			.UseSimpleAssemblyNameTypeSerializer()
			.UseRecommendedSerializerSettings()
			.UseColouredConsoleLogProvider());
			GlobalConfiguration.Configuration.UseStorage(new MySqlStorage(connectionString, new MySqlStorageOptions
			{
				TransactionIsolationLevel = IsolationLevel.ReadCommitted,
				QueuePollInterval = TimeSpan.FromSeconds(15),
				JobExpirationCheckInterval = TimeSpan.FromHours(1),
				CountersAggregateInterval = TimeSpan.FromMinutes(5),
				PrepareSchemaIfNecessary = true,
				DashboardJobListLimit = 50000,
				TransactionTimeout = TimeSpan.FromMinutes(1),
				TablesPrefix = "Hangfire"
			}));
			builder.Services.AddHangfireServer();

			// Add services to the container.
			builder.Services.AddRazorPages();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Error");
			}
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapRazorPages();
			app.UseHangfireDashboard();

			app.Run();
		}
	}
}
