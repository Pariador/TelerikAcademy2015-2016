namespace CustomHashCollections
{ 
	using System;

    public static class Program
	{
		public static void UseHashTable()
		{
			var table = new HashTable<string, string>();

			table.Add("derp", "This is derp.");
			table.Add("magic", "Whoa magic.");
			table.Add("boots", "These boots are made for walking, and that's just what they'll do. One of these days these boots are gona walk all over you. Yeah.");

			Console.WriteLine(table["derp"]);
			Console.WriteLine(table["magic"]);
			Console.WriteLine(table["boots"]);

			Console.WriteLine("\nMagic removed? {0}.", table.Remove("magic") ? "Yes" : "No");
			Console.WriteLine("\nIs there magic now? {0}.", table.ContainsKey("magic") ? "Yes" : "No");
			Console.WriteLine(":(");
		}

		public static void UseHashSet()
		{
			var set = new Set<string>();

			set.Add("Huey");
			set.Add("Louie");
			set.Add("Dewey");
			set.Add("Donald");
			set.Add("Daisy");
			set.Add("Scrooge");

			Console.WriteLine("Is Scrooge here, he's awesome? {0}.", set.Contains("Scrooge") ? "Yes" : "No");

			Console.WriteLine("\nEven more Disney characters:");
			set.UnionWith(new[] { "Micky", "Minnie", "Goofy", "Pluto" });
			Console.WriteLine(string.Join(", ", set));

			Console.WriteLine("\nJust the ducklings:");
			set.IntersectWith(new[] { "Huey", "Louie", "Dewey", "Darth Vader" });
			Console.WriteLine(string.Join(", ", set));
		}

		public static void Main()
		{
			Console.WriteLine("--------HashTable--------");
			Program.UseHashTable();
			Console.WriteLine("\n--------Set--------");
			Program.UseHashSet();
		}
	}
}