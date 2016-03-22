using System;

namespace FilesAndFolders
{
	using System.IO;
	using System.Linq;
	using System.Numerics;
	using System.Collections.Generic;

	public class Folder
	{
		private List<Folder> folders;

		private Folder(string name)
		{
			this.Name = name;
			this.folders = new List<Folder>();
		}

		public string Name { get; private set; }

		public IEnumerable<Folder> Folders
		{
			get
			{
				return this.folders;
			}
		}

		public IEnumerable<File> Files { get; private set; }

		public static Folder LoadFolder(string path)
		{
			return Folder.LoadFolder(new DirectoryInfo(path));
		}

		private static Folder LoadFolder(DirectoryInfo directory)
		{
			Folder result = new Folder(directory.Name);

			DirectoryInfo[] directories;
			try
			{
				directories = directory.GetDirectories();

			}
			catch (UnauthorizedAccessException)
			{
				return null;

			}

			foreach (var dir in directories)
			{
				var folder = Folder.LoadFolder(dir);

				if (folder != null)
				{
					result.folders.Add(folder);
				}
			}

			var files = directory.GetFiles();

			result.Files = files.Select(file => new File(file.Name, file.Length));

			return result;
		}

		public BigInteger SumFileSizes()
		{
			BigInteger sum = 0;

			foreach (var file in this.Files)
			{
				sum += file.SizeInBytes;
			}

			foreach (var folder in this.Folders)
			{
				sum += folder.SumFileSizes();
			}

			return sum;
		}
	}
}