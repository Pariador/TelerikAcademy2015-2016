namespace FindExecutables
{
	using System;
	using System.IO;

	public static class Start
	{
		public static void Main()
		{
			// Path set to current project directory. Running in in C:\Windows takes too long. :)
			string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

			const string FileExtension = ".exe";

			var files = FileFinder.FindFiles(path, FileExtension);

			foreach (var file in files)
			{
				Console.WriteLine(file);
			}
		}
	}
}