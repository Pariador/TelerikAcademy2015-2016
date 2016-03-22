namespace FindExecutables
{
	using System;
	using System.IO;
	using System.Linq;
	using System.Collections.Generic;

	public static class FileFinder
	{
		public static List<string> FindFiles(string path, string fileExtension)
		{
			return FileFinder.FindFiles(new DirectoryInfo(path), fileExtension);
		}

		public static List<string> FindFiles(DirectoryInfo directory, string fileExtension)
		{
			List<string> result = new List<string>();

			DirectoryInfo[] directories;
			try
			{
				directories = directory.GetDirectories();
			}
			catch (UnauthorizedAccessException)
			{
				return result;
			}

			foreach (var dir in directories)
			{
				result.AddRange(FileFinder.FindFiles(dir, fileExtension));
			}

			var files = directory.GetFiles()
				.Where(file => file.Extension == fileExtension)
				.Select(f => f.Name);

			result.AddRange(files);

			return result;
		}

		public static string GetFileName(string path)
		{
			int fileNameStart = path.LastIndexOf('\\') + 1;

			if (fileNameStart == -1)
			{
				return string.Empty;
			}

			return path.Substring(fileNameStart);
		}
	}
}