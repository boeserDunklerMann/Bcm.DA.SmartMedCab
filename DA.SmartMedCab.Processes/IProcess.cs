namespace DA.SmartMedCab.Processes
{
	public interface IProcess
	{
		string Name { get; }
		Task RunAsync();
	}
}
