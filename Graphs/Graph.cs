using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graphs
{
	public class Graph
	{
		private class Node
		{
			public string Label;

			public Node(string label)
			{
				Label = label;
			}

			public override string ToString()
			{
				return $"{Label}";
			}
		}

		private IDictionary<string, Node> nodes = new Dictionary<string, Node>();
		private IDictionary<Node, List<Node>> adjacencyList = new Dictionary<Node, List<Node>>();

		public void AddNode(string label)
		{
			var node = new Node(label);
			if (!nodes.ContainsKey(label))
				nodes.Add(label, node);
			if (!adjacencyList.ContainsKey(node))
				adjacencyList.Add(node, new List<Node>());
		}

		public void AddEdge(string from, string to)
		{
			if (!nodes.ContainsKey(from) || !nodes.ContainsKey(to)) return;

			var toNode = nodes[to];
			var fromNode = nodes[from];
			adjacencyList[fromNode].Add(toNode);
		}

		public void Remove(string label)
		{
			if (!nodes.ContainsKey(label)) return;

			var node = nodes[label];

			// Remove link
			foreach (var n in adjacencyList.Keys)
				adjacencyList[n].Remove(node);

			adjacencyList.Remove(node);
			nodes.Remove(label) ;
		}

		public void RemoveEdge(string from, string to)
		{
			if (!nodes.ContainsKey(from) || !nodes.ContainsKey(to)) return;

			var toNode = nodes[to];
			var fromNode = nodes[from];
			adjacencyList[fromNode].Remove(toNode);
		}

		public void Print()
		{
			foreach(var source in adjacencyList.Keys)
			{
				var targets = adjacencyList[source];
				if(targets.Any())
					Console.WriteLine($"{source} is connected to [{string.Join(",", targets)}].");
			}
		}

		public void TraverseDepthFirst(string label)
		{
			if (!nodes.ContainsKey(label)) return;

			var node = nodes[label];
			TraverseDepthFirst(node, new HashSet<Node>());
		}

		private void TraverseDepthFirst(Node node, HashSet<Node> hashSet)
		{
			Console.WriteLine(node);
			hashSet.Add(node);

			foreach (var n in adjacencyList[node])
			{
				if (!hashSet.Contains(n))
					TraverseDepthFirst(n, hashSet);
			}
		}

		public void TraverseDepthFirstIterative(string label)
		{
			if (!nodes.ContainsKey(label)) return;

			var node = nodes[label];

			var stack = new Stack<Node>();
			var visited = new HashSet<Node>();
			stack.Push(node);

			while(stack.Any())
			{
				var current = stack.Pop();

				if (visited.Contains(current)) continue;

				Console.WriteLine(current);
				visited.Add(node);

				foreach (var neightbour in adjacencyList[current])
				{
					if (!visited.Contains(neightbour))
						stack.Push(neightbour);
				}
			}

		}

		public void TraverseBreadthFirstIterative(string label)
		{
			if (!nodes.ContainsKey(label)) return;

			var node = nodes[label];

			var queue = new Queue<Node>();
			var visited = new HashSet<Node>();
			queue.Enqueue(node);

			while (queue.Any())
			{
				var current = queue.Dequeue();

				if (visited.Contains(current)) continue;

				Console.WriteLine(current);
				visited.Add(node);

				foreach (var neightbour in adjacencyList[current])
				{
					if (!visited.Contains(neightbour))
						queue.Enqueue(neightbour);
				}
			}
		}

		public IList<string> TopologicalSort()
		{
			var stack = new Stack<Node>();
			var visited = new HashSet<Node>();

			foreach (var node in nodes.Values)
				TopologicalSort(node, visited, stack);

			var sorted = new List<string>();
			foreach (var item in stack)
				sorted.Add(item.Label);
			return sorted;
		}

		private void TopologicalSort(Node node, HashSet<Node> visited, Stack<Node> stack)
		{
			if (visited.Contains(node)) return;

			visited.Add(node);

			foreach (var neighbour in adjacencyList[node])
				TopologicalSort(neighbour, visited, stack);

			stack.Push(node);
		}

		public bool HasCycle()
		{
			var all = new HashSet<Node>();
			foreach (var n in nodes.Values)
				all.Add(n);
			var visiting = new HashSet<Node>();
			var visited = new HashSet<Node>();

			while(all.Any())
			{
				var current = all.FirstOrDefault();
				if (HasCycle(current, all, visiting, visited))
					return true;
			}
			return false;
		}

		private bool HasCycle(Node node, HashSet<Node> all, HashSet<Node> visiting, HashSet<Node> visited)
		{
			all.Remove(node);
			visiting.Add(node);

			foreach (var neighbour in adjacencyList[node])
			{
				if (visited.Contains(neighbour))
					continue;
				if (visiting.Contains(neighbour))
					return true;

				if (HasCycle(neighbour, all, visiting, visited)) return true;
			}

			visiting.Remove(node);
			visited.Add(node);
			return false;
		}
	}
}
