namespace FilesAndFolders
{
	using System;
	using System.IO;

	public static class Start
	{
		public static void Main()
		{
			// Path set to current project directory. Running in in C:\Windows takes too long. :)
			string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

			var folder = Folder.LoadFolder(path);

			Console.WriteLine(folder.SumFileSizes());
		}
	}
}