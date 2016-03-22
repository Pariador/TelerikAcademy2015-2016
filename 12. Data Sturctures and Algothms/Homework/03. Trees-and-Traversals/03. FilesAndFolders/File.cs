namespace FilesAndFolders
{
	public class File
	{
		public File(string name, long sizeInBytes)
		{
			this.Name = name;
			this.SizeInBytes = sizeInBytes;
		}

		public string Name { get; private set; }

		public long SizeInBytes { get; private set; }
	}
}