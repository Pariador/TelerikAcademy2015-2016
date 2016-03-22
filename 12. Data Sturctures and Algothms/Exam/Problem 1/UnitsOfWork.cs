namespace Problem1
{
	using System;
	using System.Linq;
	using System.Text;
	using System.Collections.Generic;

	using Wintellect.PowerCollections;

	public static class UnitsOfWork
	{
		public static Dictionary<string, Unit> Units = new Dictionary<string, Unit>();

		public static OrderedMultiDictionary<string, Unit> ByType = new OrderedMultiDictionary<string, Unit>(allowDuplicateValues: true);

		public static SortedSet<Unit> ByAttack = new SortedSet<Unit>();

		public const string Success = "SUCCESS:";

		public const string Fail = "FAIL:";

		public static StringBuilder Output = new StringBuilder();

		public static void Main()
		{
			//Console.SetIn(new System.IO.StreamReader("Inputs/test.000.001.in.txt"));
			//Console.SetOut(new System.IO.StreamWriter("MY_OUTPUT.txt"));

			while (true)
			{
				string line = Console.ReadLine();

				if (line == "end")
				{
					break;
				}

				string[] args = line.Split(' ');

				string command = args[0];

				if (command == "add")
				{
					string name = args[1];
					string type = args[2];
					int attack = int.Parse(args[3]);

					bool added = UnitsOfWork.AddUnit(name, type, attack);

					if (added)
					{
						UnitsOfWork.PrintSuccessfulAdd(name);
					}
					else
					{
						UnitsOfWork.PrintFailedAdd(name);
					}
				}
				else if (command == "remove")
				{
					string name = args[1];

					bool removed = UnitsOfWork.RemoveUnit(name);

					if (removed)
					{
						UnitsOfWork.PrintSuccessfulRemove(name);
					}
					else
					{
						UnitsOfWork.PrintFailedRemove(name);
					}
				}
				else if (command == "find")
				{
					string type = args[1];

					var units = UnitsOfWork.GetUnitsByType(type);

					UnitsOfWork.PrintUnits(units);
				}
				else if (command == "power")
				{
					int take = int.Parse(args[1]);

					var units = UnitsOfWork.GetUnitsByPower(take);

					UnitsOfWork.PrintUnits(units);
				}
			}

			//new System.IO.StreamWriter("MY_OUTPUT.txt").Write(UnitsOfWork.Output);
			Console.Write(UnitsOfWork.Output);
		}

		public static bool AddUnit(string name, string type, int attack)
		{
			if (UnitsOfWork.Units.ContainsKey(name))
			{
				return false;
			}

			Unit unit = new Unit(name, type, attack);

			UnitsOfWork.Units[unit.Name] = unit;
			UnitsOfWork.ByType[unit.Type].Add(unit);
			UnitsOfWork.ByAttack.Add(unit);


			return true;
		}

		public static bool RemoveUnit(string name)
		{
			if (!UnitsOfWork.Units.ContainsKey(name))
			{
				return false;
			}

			Unit unit = UnitsOfWork.Units[name];

			return UnitsOfWork.Units.Remove(unit.Name) &&
			UnitsOfWork.ByType[unit.Type].Remove(unit) &&
			UnitsOfWork.ByAttack.Remove(unit);
		}

		public static IEnumerable<Unit> GetUnitsByType(string type)
		{
			if (!UnitsOfWork.ByType.ContainsKey(type))
			{
				return new Unit[0];
			}

			return UnitsOfWork.ByType[type].Take(10);
		}

		public static IEnumerable<Unit> GetUnitsByPower(int take)
		{
			var res = UnitsOfWork.ByAttack
				//.Select(p => p.Value)
				//.Aggregate(new Unit[0] as IEnumerable<Unit>, (prev, next) => prev.Concat(next))
				.Take(take);

			return res;
		}

		public static void PrintSuccessfulAdd(string name)
		{
			string line = string.Format("{0} {1} added!", UnitsOfWork.Success, name);
			UnitsOfWork.Output.AppendLine(line);
		}
		public static void PrintFailedAdd(string name)
		{
			string line = string.Format("{0} {1} already exists!", UnitsOfWork.Fail, name);
			UnitsOfWork.Output.AppendLine(line);
		}

		public static void PrintSuccessfulRemove(string name)
		{
			string line = string.Format("{0} {1} removed!", UnitsOfWork.Success, name);
			UnitsOfWork.Output.AppendLine(line);
		}

		public static void PrintFailedRemove(string name)
		{
			string line = string.Format("{0} {1} could not be found!", UnitsOfWork.Fail, name);
			UnitsOfWork.Output.AppendLine(line);
		}

		public static void PrintUnits(IEnumerable<Unit> units)
		{
			UnitsOfWork.Output.AppendLine("RESULT: " + string.Join(", ", units));
		}
	}

	public class Unit : IComparable<Unit>
	{
		public Unit(string name, string type, int attack)
		{
			this.Name = name;
			this.Type = type;
			this.Attack = attack;
		}

		public string Name { get; private set; }

		public string Type { get; private set; }

		public int Attack { get; private set; }

		public int CompareTo(Unit other)
		{
			int attackCompare = other.Attack.CompareTo(this.Attack);

			if (attackCompare == 0)
			{
				return this.Name.CompareTo(other.Name);
			}

			return attackCompare;
		}

		public override string ToString()
		{
			return string.Format("{0}[{1}]({2})", this.Name, this.Type, this.Attack);
		}
	}
}