using DA.SmartMedCab.Processes;
using Hangfire;
using Hangfire.MySql;
using System.Transactions;

namespace DA.SmartMedCab.ProcessServer.Test
{
	internal class Program
	{
		static void Main(string[] args)
		{
			GlobalConfiguration.Configuration.SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
				.UseColouredConsoleLogProvider()
				.UseSimpleAssemblyNameTypeSerializer()
				.UseRecommendedSerializerSettings()
				.UseStorage(
				new MySqlStorage("Server=localhost;Database=DA_SmartMedCab_Hangfire;Uid=DA.SmartMedCab.Hangfire;Pwd=hangfire.0815;Allow User Variables=true", new MySqlStorageOptions
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

			IProcess proc = Commons.ContractBinder.GetObject<IProcess>();
			if (proc != null)
			{
				BackgroundJob.Enqueue(() => proc.RunAsync());
			}
		}
	}
}
