using System.Collections.Generic;

namespace DataStructures.Graphs
{
	public class Path
	{
		public IList<string> Nodes = new List<string>(); 

		public void Add(string node) => Nodes.Add(node);

		public override string ToString()
		{
			return $"{string.Join(",", Nodes)}";
		}
	}
}
