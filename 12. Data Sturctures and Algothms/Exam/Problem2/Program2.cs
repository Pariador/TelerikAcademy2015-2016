namespace Problem2
{
	using System;
	using System.Linq;
	using System.Collections.Generic;

	public static class Program2
	{
		public static void Main()
		{
			int nodesCount = int.Parse(Console.ReadLine());

			Node[] nodes = new Node[nodesCount];

			int[] times = Console.ReadLine()
				.Split(' ')
				.Select(int.Parse)
				.ToArray();

			for (int i = 0; i < nodes.Length; i++)
			{
				nodes[i] = new Node(times[i]);
			}


			var graph = new Dictionary<Node, HashSet<Node>>();
			for (int i = 0; i < nodes.Length; i++)
			{
				int[] dependencies = Console.ReadLine()
					.Split(' ')
					.Select(int.Parse)
					.ToArray();

				Node node = nodes[i];

				graph[node] = new HashSet<Node>();

				if (dependencies[0] != 0)
				{
					foreach (var dependency in dependencies)
					{
						graph[node].Add(nodes[dependency - 1]);
					}
				}
			}

			int result = Solve(graph);
			Console.WriteLine(result);
		}

		public static int Solve(Dictionary<Node, HashSet<Node>> graph)
		{
			//var newValidResolvedNodes = new HashSet<Node>();
			var resolvedNodes = new HashSet<Node>();
			int timeSum = 0;
			while (graph.Count != 0)
			{
				var noDep = graph.Where(pair => pair.Value.Count == 0).Select(pair => pair.Key);

				if (!noDep.Any())
				{
					return -1;
				}

				int minTime = noDep.Min(node => node.Time);
				foreach (var node in noDep)
				{
					node.Time -= minTime;
					if (node.Time <= 0)
					{
						resolvedNodes.Add(node);
					}
				}

				ResolveNodes(resolvedNodes, graph);

				timeSum += minTime;
			}

			return timeSum;
		}

		public static void ResolveNodes(IEnumerable<Node> nodes, Dictionary<Node, HashSet<Node>> graph)
		{
			foreach (var node in nodes)
			{
				graph.Remove(node);
			}

			foreach (var node in graph)
			{
				node.Value.ExceptWith(nodes);
			}
		}

		public static void ResolveNode(Node node, Dictionary<Node, HashSet<Node>> graph)
		{
			graph.Remove(node);

			foreach (var otherNode in graph)
			{
				otherNode.Value.Remove(node);
			}
		}
	}

	public class Node
	{
		public Node(int time)
		{
			this.Time = time;
		}

		public int Time { get; set; }
	}
}