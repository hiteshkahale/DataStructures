using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graphs
{
	public class WeightedGraph
	{
		private class Node
		{
			public string Label;
			public IList<Edge> Edges = new List<Edge>();

			public Node(string label)
			{
				Label = label;
			}

			public void AddEdge(Node to, int weight)
			{
				Edges.Add(new Edge(this, to, weight));
			}

			public IList<Edge> GetEdges() => Edges;

			public override string ToString()
			{
				return $"{Label}";
			}
		}

		private class Edge : IComparable<Edge>
		{
			public Node From { get; private set; }
			public Node To { get; private set; }
			public int Weight { get; private set; }

			public Edge(Node from, Node to, int weight)
			{
				From = from;
				To = to;
				Weight = weight;
			}

			public override string ToString()
			{
				return $"{From} -> {To}={Weight}";
			}

			public int CompareTo(Edge other)
			{
				if(Weight < other.Weight) return -1;
				else if (Weight > other.Weight) return 1;
				else return 0;
			}
		}

		private class NodeEntry : IComparable<NodeEntry>
		{
			public Node Node { get; private set; }
			public int Priority { get; private set; }

			public NodeEntry(Node node, int priority)
			{
				Node = node;
				Priority = priority;
			}

			public int CompareTo(NodeEntry other)
			{
				if (Priority < other.Priority) return -1;
				else if (Priority > other.Priority) return 1;
				else return 0;
			}
		}

		private IDictionary<string, Node> nodes = new Dictionary<string, Node>();

		public void AddNode(string label)
		{
			if (!nodes.ContainsKey(label))
				nodes.Add(label, new Node(label));
		}

		public void AddEdge(string from, string to, int weight)
		{
			if (!nodes.ContainsKey(from) || !nodes.ContainsKey(to)) return;

			var toNode = nodes[to];
			var fromNode = nodes[from];
			toNode.AddEdge(fromNode, weight);
			fromNode.AddEdge(toNode, weight);
		}


		public void Print()
		{
			foreach (var node in nodes.Values)
			{
				if (node.GetEdges().Any())
					Console.WriteLine($"{node} is connected to [{string.Join(",", node.GetEdges())}].");
			}
		}

		/// <summary>
		/// Dijkstra's algorithm to find the minimum distance between two nodes.
		/// </summary>
		/// <param name="from"></param>
		/// <param name="to"></param>
		/// <returns></returns>
		public Path GetShortestPath(string from, string to)
		{
			if (!nodes.ContainsKey(from) || !nodes.ContainsKey(to)) return null;

			var fromNode = nodes[from];
			var toNode = nodes[to];
			var distances = new Dictionary<Node, int>();
			foreach (var node in nodes.Values)
				distances.Add(node, int.MaxValue);

			distances[fromNode] = 0;
			var previousNodes = new Dictionary<Node, Node>();

			var visited = new HashSet<Node>();
			var queue = new PriorityQueue<NodeEntry>();
			queue.Enqueue(new NodeEntry(fromNode, 0));

			while(queue.Count() != 0)
			{
				var current = queue.Dequeue().Node;
				visited.Add(current);

				foreach (var edge in current.GetEdges())
				{
					if (visited.Contains(edge.To)) continue;
					var newDistance = distances[current] + edge.Weight; // 0 + Edge weight
					if (newDistance < distances[edge.To])
					{
						distances[edge.To] = newDistance;
						previousNodes[edge.To] = current;
						queue.Enqueue(new NodeEntry(edge.To, newDistance));
					}
				}
			}

			return BuildPath(previousNodes, toNode);
		}

		private Path BuildPath(Dictionary<Node, Node> previousNodes, Node toNode)
		{
			var stack = new Stack<Node>();
			stack.Push(toNode);
			var previous = previousNodes.ContainsKey(toNode) ? previousNodes[toNode] : null;
			while (previous != null)
			{
				stack.Push(previous);
				previous = previousNodes.ContainsKey(previous) ? previousNodes[previous] : null;
			}
			var path = new Path();
			while (stack.Any())
				path.Add(stack.Pop().Label);
			return path;
		}

		public bool HasCycle()
		{
			var visited = new HashSet<Node>();

			foreach (var node in nodes.Values)
				if (!visited.Contains(node) && HasCycle(node, null, visited)) return true;
			return false;
		}

		private bool HasCycle(Node node, Node parent, HashSet<Node> visited)
		{
			visited.Add(node);

			foreach (var edge in node.GetEdges())
			{
				if (edge.To == parent) continue;
				if (visited.Contains(edge.To) || HasCycle(edge.To, node, visited)) return true;
			}
			return false;
		}

		public WeightedGraph GetMinimumSpanningTree()
		{
			var tree = new WeightedGraph();
			if (!nodes.Any()) return tree;

			var edges = new PriorityQueue<Edge>();
			var startNode = nodes.FirstOrDefault().Value;
			foreach (var edge in startNode.GetEdges())
				edges.Enqueue(edge);
			tree.AddNode(startNode.Label);

			if (edges.Count() == 0) return tree;

			while(tree.nodes.Count() < nodes.Count())
			{
				var minEdge = edges.Dequeue();
				var nextNode = minEdge.To;

				if (tree.ContainsNode(nextNode.Label)) continue;

				tree.AddNode(nextNode.Label);
				tree.AddEdge(minEdge.From.Label, nextNode.Label, minEdge.Weight);

				foreach (var edge in nextNode.GetEdges())
				{
					if (!tree.ContainsNode(edge.To.Label))
						edges.Enqueue(edge);
				}
			}
			return tree;
		}

		public bool ContainsNode(string label) => nodes.ContainsKey(label);
	}
}
