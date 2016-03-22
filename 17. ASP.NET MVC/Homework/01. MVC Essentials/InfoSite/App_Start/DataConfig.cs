namespace InfoSite
{
	using Data;

	public static class DataConfig
	{
		public static void Init(string dataPath)
		{
			Database.Seed(dataPath);
		}
	}
}